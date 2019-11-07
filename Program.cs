using System;
using System.Runtime.InteropServices;

namespace stay_awake
{
    internal enum AwakeMode { Away, Display, System }

    [FlagsAttribute]
    internal enum ExecutionState : uint
    {
        ES_AWAYMODE_REQUIRED = 0x00000040,
        ES_CONTINUOUS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001
        // Legacy flag, should not be used.
        // ES_USER_PRESENT = 0x00000004
    }
    class Program
    {
        // Validation performed with powercfg -requests

        // https://www.pinvoke.net/default.aspx/kernel32/SetThreadExecutionState.html
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        private static void SetMode(AwakeMode aMode, ExecutionState eState)
        {
            Console.WriteLine($"Staying awake with mode: {aMode}");

            try
            {
                Console.WriteLine($"Executing SetThreadExecutionState({eState} | ES_CONTINUOUS)");

                SetThreadExecutionState(eState | ExecutionState.ES_CONTINUOUS);

                Console.WriteLine("Press ``Enter`` to stop staying awake");
                var _ = Console.ReadLine();
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Unable to execute SetThreadExecutionState({eState} | ES_CONTINUOUS)");
                Console.WriteLine($"The relevant error message is {e.Message}");
            }
            finally
            {
                Console.WriteLine("Stopping stayawake");
                Console.WriteLine($"Executing SetThreadExecutionState(ES_CONTINUOUS)");

                SetThreadExecutionState(ExecutionState.ES_CONTINUOUS);
            }
        }

        /// <summary>keep the computer awake</summary>
        /// <param name="awakeMode">Away ==> Enable away mode ; Display ==> Keep the display on ; System ==> Do not sleep</param>
        static int Main(AwakeMode awakeMode = AwakeMode.Display)
        {
            switch(awakeMode)
            {
                case AwakeMode.Away:
                    SetMode(awakeMode, ExecutionState.ES_AWAYMODE_REQUIRED);
                    break;
                case AwakeMode.Display:
                    SetMode(awakeMode, ExecutionState.ES_DISPLAY_REQUIRED);
                    break;
                case AwakeMode.System:
                    SetMode(awakeMode, ExecutionState.ES_SYSTEM_REQUIRED);
                    break;
                default:
                    Console.WriteLine("Awake mode has not been set.");
                    break;
            }

            return 0;
        }
    }
}
