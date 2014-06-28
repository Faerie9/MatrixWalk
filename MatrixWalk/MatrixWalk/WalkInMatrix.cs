namespace MatrixWalk
{
    /// <summary>
    /// This namespace contains classes to solve the Walk in matrix problem.
    /// </summary>
    /// 
    using System;
    using System.Linq;
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Layout;
    using log4net.Core;

    class WalkInMatrix
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WalkInMatrix));

        static void Main()
        {
            var fileAppender = new FileAppender();
            fileAppender.File = "log.txt";
            fileAppender.AppendToFile = true;
            fileAppender.Layout = new SimpleLayout();
            fileAppender.Threshold = Level.Warn;
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);

            log.Info("Before program start.");

            Matrix matrix = new Matrix(6);
            Walk walkInTheMatrix = new Walk(matrix);
            walkInTheMatrix.StartWalk();

            log.Info("After program start.");
            log.Error("Some error.");
            log.Warn("Some warning.");
        }
    }
}
