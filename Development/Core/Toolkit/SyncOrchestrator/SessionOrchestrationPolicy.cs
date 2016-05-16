﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.TeamFoundation.Migration.BusinessModel;

namespace Microsoft.TeamFoundation.Migration.Toolkit
{   
    enum WorkFlow
    {
        Unknown = 0,
        Migration = 1,
        Synchronization = 2,
    }

    class SessionOrchestrationPolicy
    {
        internal class StopSessionException : Exception
        {
        }

        internal class StopSingleTripException : Exception
        {
        }

        private WorkFlowType m_workFlowType;
        private const int ResumePollingMilliSecs = 1000;
        private SyncStateMachine m_syncStateMachine;

        public SessionOrchestrationPolicy(
            WorkFlowType workFlowType,
            SyncStateMachine syncStateMachine)
        {
            m_workFlowType = workFlowType;
            m_syncStateMachine = syncStateMachine;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Check()
        {
            // transit from intermittent state to stable state
            switch (m_syncStateMachine.CurrentState)
            {
                case PipelineState.Pausing:
                    m_syncStateMachine.CommandTransitFinished(PipelineSyncCommand.PAUSE);
                    break;
                case PipelineState.Starting:
                    m_syncStateMachine.CommandTransitFinished(PipelineSyncCommand.START);
                    break;
                case PipelineState.Stopping:
                    m_syncStateMachine.CommandTransitFinished(PipelineSyncCommand.STOP);
                    break;
                case PipelineState.StoppingSingleTrip:
                    m_syncStateMachine.CommandTransitFinished(PipelineSyncCommand.STOP_CURRENT_TRIP);
                    break;
                default:
                    break;
            }

            while (m_syncStateMachine.CurrentState == PipelineState.Paused)
            {
                // sleep at "PAUSED"
                Thread.Sleep(ResumePollingMilliSecs);
            }

            switch (m_syncStateMachine.CurrentState)
            {
                case PipelineState.Paused:
                    // if this really happens, we simply proceed to next check point
                    break;
                case PipelineState.Running:
                    break;
                case PipelineState.Stopped:
                    throw new StopSessionException();
                case PipelineState.StoppedSingleTrip:
                    throw new StopSingleTripException();
                default:
                    break;
            }
        }

        internal WorkFlowType WorkFlowType
        {
            get { return m_workFlowType; }
        }

        internal bool TryStartNextRoundTrip(int sleepSecs)
        {            
            // only start another round trip for synchronization sessions
            if (WorkFlowType.Frequency != Frequency.ContinuousAutomatic)
            {
                return false;
            }

            try
            {
                // in case the session is requested to PAUSE
                Check();

                Thread.Sleep(sleepSecs);
                m_syncStateMachine.TryTransit(PipelineSyncCommand.START_NEW_TRIP);

                return true;
            }
            catch (StopSessionException)
            {
                return false;
            }
            catch (StopSingleTripException)
            {
                Thread.Sleep(sleepSecs);
                m_syncStateMachine.TryTransit(PipelineSyncCommand.START_NEW_TRIP);
                return true;
            }
        }
    }
}