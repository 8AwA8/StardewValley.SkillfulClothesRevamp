using System;
using StardewModdingAPI;

namespace SkillfulClothes
{
	// Token: 0x02000013 RID: 19
	internal static class Logger
	{
		// Token: 0x06000060 RID: 96 RVA: 0x0000234A File Offset: 0x0000054A
		public static void Init(IMonitor _monitor, bool _verbose)
		{
			Logger.monitor = _monitor;
			Logger.verbose = _verbose;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002358 File Offset: 0x00000558
		public static void Info(string message)
		{
			if (Logger.verbose)
			{
				IMonitor monitor = Logger.monitor;
				if (monitor == null)
				{
					return;
				}
				monitor.Log(message, StardewModdingAPI.LogLevel.Info);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002372 File Offset: 0x00000572
		public static void Debug(string message)
		{
			if (Logger.verbose)
			{
				IMonitor monitor = Logger.monitor;
				if (monitor == null)
				{
					return;
				}
				monitor.Log(message, LogLevel.Debug);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000238C File Offset: 0x0000058C
		public static void Warn(string message)
		{
			if (Logger.verbose)
			{
				IMonitor monitor = Logger.monitor;
				if (monitor == null)
				{
					return;
				}
				monitor.Log(message, LogLevel.Warn);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000023A6 File Offset: 0x000005A6
		public static void Error(string message)
		{
			IMonitor monitor = Logger.monitor;
			if (monitor == null)
			{
				return;
			}
			monitor.Log(message, LogLevel.Error);
		}

		// Token: 0x04000027 RID: 39
		private static IMonitor monitor;

		// Token: 0x04000028 RID: 40
		private static bool verbose;
	}
}
