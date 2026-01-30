using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SkillfulClothes.Types
{
	// Token: 0x0200002A RID: 42
	public static class KnownShirts
	{
		// Token: 0x06000104 RID: 260 RVA: 0x00007FAC File Offset: 0x000061AC
		static KnownShirts()
		{
			foreach (FieldInfo field in from x in typeof(KnownShirts).GetFields(BindingFlags.Static | BindingFlags.Public)
			where x.FieldType == typeof(Shirt)
			select x)
			{
				Shirt shirt = field.GetValue(null) as Shirt;
				shirt.ItemName = field.Name;
				KnownShirts.lut_ids.Add(shirt.ItemId, shirt);
				KnownShirts.lut_names.Add(shirt.ItemName, shirt);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00008BF8 File Offset: 0x00006DF8
		public static Shirt GetById(string itemId)
		{
			if (itemId == null)
			{
				return KnownShirts.None;
			}
			Shirt knownShirt;
			if (KnownShirts.lut_ids.TryGetValue(itemId, out knownShirt) || KnownShirts.lut_names.TryGetValue(itemId, out knownShirt))
			{
				return knownShirt;
			}
			return new Shirt(itemId)
			{
				ItemName = itemId
			};
		}

		// Token: 0x040000DC RID: 220
		public static Shirt None = -1;

		// Token: 0x040000DD RID: 221
		public static Shirt ClassicOveralls = 1000;

		// Token: 0x040000DE RID: 222
		public static Shirt MintBlouse = 1002;

		// Token: 0x040000DF RID: 223
		public static Shirt DarkShirt = 1003;

		// Token: 0x040000E0 RID: 224
		public static Shirt SkullShirt = 1004;

		// Token: 0x040000E1 RID: 225
		public static Shirt LightBlueShirt = 1005;

		// Token: 0x040000E2 RID: 226
		public static Shirt TanStripedShirt = 1006;

		// Token: 0x040000E3 RID: 227
		public static Shirt GreenOveralls = 1007;

		// Token: 0x040000E4 RID: 228
		public static Shirt GoodGriefShirt = 1008;

		// Token: 0x040000E5 RID: 229
		public static Shirt AquamarineShirt = 1009;

		// Token: 0x040000E6 RID: 230
		public static Shirt SuitTop = 1010;

		// Token: 0x040000E7 RID: 231
		public static Shirt GreenBeltedShirt = 1011;

		// Token: 0x040000E8 RID: 232
		public static Shirt LimeGreenStripedShirt = 1012;

		// Token: 0x040000E9 RID: 233
		public static Shirt RedStripedShirt = 1013;

		// Token: 0x040000EA RID: 234
		public static Shirt SkeletonShirt = 1014;

		// Token: 0x040000EB RID: 235
		public static Shirt OrangeShirt = 1015;

		// Token: 0x040000EC RID: 236
		public static Shirt NightSkyShirt = 1016;

		// Token: 0x040000ED RID: 237
		public static Shirt MayoralSuspenders = 1017;

		// Token: 0x040000EE RID: 238
		public static Shirt BrownJacket = 1018;

		// Token: 0x040000EF RID: 239
		public static Shirt SailorShirt = 1019;

		// Token: 0x040000F0 RID: 240
		public static Shirt GreenVest = 1020;

		// Token: 0x040000F1 RID: 241
		public static Shirt YellowandGreenShirt = 1021;

		// Token: 0x040000F2 RID: 242
		public static Shirt LightBlueStripedShirt = 1026;

		// Token: 0x040000F3 RID: 243
		public static Shirt PinkStripedShirt = 1027;

		// Token: 0x040000F4 RID: 244
		public static Shirt HeartShirt = 1028;

		// Token: 0x040000F5 RID: 245
		public static Shirt WorkShirt = 1029;

		// Token: 0x040000F6 RID: 246
		public static Shirt StoreOwnersJacket = 1030;

		// Token: 0x040000F7 RID: 247
		public static Shirt GreenTunic = 1034;

		// Token: 0x040000F8 RID: 248
		public static Shirt FancyRedBlouse = 1035;

		// Token: 0x040000F9 RID: 249
		public static Shirt PlainShirt = 1038;

		// Token: 0x040000FA RID: 250
		public static Shirt RetroRainbowShirt = 1039;

		// Token: 0x040000FB RID: 251
		public static Shirt LimeGreenTunic = 1042;

		// Token: 0x040000FC RID: 252
		public static Shirt NeatBowShirt = 1087;

		// Token: 0x040000FD RID: 253
		public static Shirt ShirtAndTie = 1123;

		// Token: 0x040000FE RID: 254
		public static Shirt EmilysMagicShirt = 1127;

		// Token: 0x040000FF RID: 255
		public static Shirt StripedShirt = 1128;

		// Token: 0x04000100 RID: 256
		public static Shirt TankTop = 1129;

		// Token: 0x04000101 RID: 257
		public static Shirt CowboyPoncho = 1131;

		// Token: 0x04000102 RID: 258
		public static Shirt CropTankTop = 1132;

		// Token: 0x04000103 RID: 259
		public static Shirt BikiniTop = 1134;

		// Token: 0x04000104 RID: 260
		public static Shirt WumbusShirt = 1135;

		// Token: 0x04000105 RID: 261
		public static Shirt EightiesShirt = 1136;

		// Token: 0x04000106 RID: 262
		public static Shirt LettermanJacket = 1137;

		// Token: 0x04000107 RID: 263
		public static Shirt BlackLeatherJacket = 1138;

		// Token: 0x04000108 RID: 264
		public static Shirt StrappedTop = 1139;

		// Token: 0x04000109 RID: 265
		public static Shirt ButtonDownShirt = 1140;

		// Token: 0x0400010A RID: 266
		public static Shirt CropTopShirt = 1141;

		// Token: 0x0400010B RID: 267
		public static Shirt TubeTop = 1142;

		// Token: 0x0400010C RID: 268
		public static Shirt TyeDieShirt = 1143;

		// Token: 0x0400010D RID: 269
		public static Shirt SteelBreastplate = 1148;

		// Token: 0x0400010E RID: 270
		public static Shirt CopperBreastplate = 1149;

		// Token: 0x0400010F RID: 271
		public static Shirt GoldBreastplate = 1150;

		// Token: 0x04000110 RID: 272
		public static Shirt IridiumBreastplate = 1151;

		// Token: 0x04000111 RID: 273
		public static Shirt FakeMusclesShirt = 1153;

		// Token: 0x04000112 RID: 274
		public static Shirt FlannelShirt = 1154;

		// Token: 0x04000113 RID: 275
		public static Shirt BomberJacket = 1155;

		// Token: 0x04000114 RID: 276
		public static Shirt CavemanShirt = 1156;

		// Token: 0x04000115 RID: 277
		public static Shirt FishingVest = 1157;

		// Token: 0x04000116 RID: 278
		public static Shirt FishShirt = 1158;

		// Token: 0x04000117 RID: 279
		public static Shirt ShirtAndBelt = 1159;

		// Token: 0x04000118 RID: 280
		public static Shirt GrayHoodie = 1160;

		// Token: 0x04000119 RID: 281
		public static Shirt BlueHoodie = 1161;

		// Token: 0x0400011A RID: 282
		public static Shirt RedHoodie = 1162;

		// Token: 0x0400011B RID: 283
		public static Shirt DenimJacket = 1163;

		// Token: 0x0400011C RID: 284
		public static Shirt TrackJacket = 1164;

		// Token: 0x0400011D RID: 285
		public static Shirt WhiteGi = 1165;

		// Token: 0x0400011E RID: 286
		public static Shirt OrangeGi = 1166;

		// Token: 0x0400011F RID: 287
		public static Shirt GrayVest = 1167;

		// Token: 0x04000120 RID: 288
		public static Shirt KelpShirt = 1168;

		// Token: 0x04000121 RID: 289
		public static Shirt StuddedVest = 1169;

		// Token: 0x04000122 RID: 290
		public static Shirt GaudyShirt = 1170;

		// Token: 0x04000123 RID: 291
		public static Shirt OasisGown = 1171;

		// Token: 0x04000124 RID: 292
		public static Shirt BlacksmithApron = 1172;

		// Token: 0x04000125 RID: 293
		public static Shirt NeatBowShirt_2 = 1173;

		// Token: 0x04000126 RID: 294
		public static Shirt HighWaistedShirt = 1174;

		// Token: 0x04000127 RID: 295
		public static Shirt HighWaistedShirt_2 = 1175;

		// Token: 0x04000128 RID: 296
		public static Shirt BasicPullover = 1176;

		// Token: 0x04000129 RID: 297
		public static Shirt TurtleneckSweater = 1178;

		// Token: 0x0400012A RID: 298
		public static Shirt IridiumEnergyShirt = 1179;

		// Token: 0x0400012B RID: 299
		public static Shirt TunnelersJersey = 1180;

		// Token: 0x0400012C RID: 300
		public static Shirt GraySuit = 1183;

		// Token: 0x0400012D RID: 301
		public static Shirt RedTuxedo = 1184;

		// Token: 0x0400012E RID: 302
		public static Shirt NavyTuxedo = 1185;

		// Token: 0x0400012F RID: 303
		public static Shirt HolidayShirt = 1186;

		// Token: 0x04000130 RID: 304
		public static Shirt LeafyTop = 1187;

		// Token: 0x04000131 RID: 305
		public static Shirt GoodnightShirt = 1188;

		// Token: 0x04000132 RID: 306
		public static Shirt GreenBeltedShirt_WithBelt = 1189;

		// Token: 0x04000133 RID: 307
		public static Shirt HappyShirt = 1190;

		// Token: 0x04000134 RID: 308
		public static Shirt ShirtwithBow = 1191;

		// Token: 0x04000135 RID: 309
		public static Shirt JesterShirt = 1192;

		// Token: 0x04000136 RID: 310
		public static Shirt OceanShirt = 1193;

		// Token: 0x04000137 RID: 311
		public static Shirt DarkStripedShirt = 1194;

		// Token: 0x04000138 RID: 312
		public static Shirt BandanaShirt_KeepNeckClean = 1195;

		// Token: 0x04000139 RID: 313
		public static Shirt BackpackShirt = 1196;

		// Token: 0x0400013A RID: 314
		public static Shirt PurpleBlouse = 1197;

		// Token: 0x0400013B RID: 315
		public static Shirt VintagePolo = 1198;

		// Token: 0x0400013C RID: 316
		public static Shirt TogaShirt = 1199;

		// Token: 0x0400013D RID: 317
		public static Shirt StarShirt = 1200;

		// Token: 0x0400013E RID: 318
		public static Shirt ClassyTop = 1201;

		// Token: 0x0400013F RID: 319
		public static Shirt BandanaShirt_ShieldFromHarm = 1203;

		// Token: 0x04000140 RID: 320
		public static Shirt VacationShirt = 1204;

		// Token: 0x04000141 RID: 321
		public static Shirt GreenThumbShirt = 1205;

		// Token: 0x04000142 RID: 322
		public static Shirt BandanaShirt_KeepNeckSoft = 1206;

		// Token: 0x04000143 RID: 323
		public static Shirt SlimeShirt = 1207;

		// Token: 0x04000144 RID: 324
		public static Shirt ExcavatorShirt = 1208;

		// Token: 0x04000145 RID: 325
		public static Shirt SportsShirt = 1209;

		// Token: 0x04000146 RID: 326
		public static Shirt HeartShirt_Dyeable = 1210;

		// Token: 0x04000147 RID: 327
		public static Shirt DarkJacket = 1211;

		// Token: 0x04000148 RID: 328
		public static Shirt SunsetShirt = 1212;

		// Token: 0x04000149 RID: 329
		public static Shirt ChefCoat = 1213;

		// Token: 0x0400014A RID: 330
		public static Shirt ShirtOfTheSea = 1214;

		// Token: 0x0400014B RID: 331
		public static Shirt ArcaneShirt = 1215;

		// Token: 0x0400014C RID: 332
		public static Shirt PlainOveralls = 1216;

		// Token: 0x0400014D RID: 333
		public static Shirt SleevelessOveralls = 1217;

		// Token: 0x0400014E RID: 334
		public static Shirt WhiteOverallsShirt = 1071;

		// Token: 0x0400014F RID: 335
		public static Shirt Cardigan = 1218;

		// Token: 0x04000150 RID: 336
		public static Shirt YobaShirt = 1219;

		// Token: 0x04000151 RID: 337
		public static Shirt NecklaceShirt = 1220;

		// Token: 0x04000152 RID: 338
		public static Shirt BeltedCoat = 1221;

		// Token: 0x04000153 RID: 339
		public static Shirt GoldTrimmedShirt = 1222;

		// Token: 0x04000154 RID: 340
		public static Shirt PrismaticShirt = 1223;

		// Token: 0x04000155 RID: 341
		public static Shirt PendantShirt = 1224;

		// Token: 0x04000156 RID: 342
		public static Shirt HighHeatShirt = 1225;

		// Token: 0x04000157 RID: 343
		public static Shirt FlamesShirt = 1226;

		// Token: 0x04000158 RID: 344
		public static Shirt AntiquityShirt = 1227;

		// Token: 0x04000159 RID: 345
		public static Shirt SoftArrowShirt = 1228;

		// Token: 0x0400015A RID: 346
		public static Shirt DollShirt = 1229;

		// Token: 0x0400015B RID: 347
		public static Shirt JewelryShirt = 1230;

		// Token: 0x0400015C RID: 348
		public static Shirt CanvasJacket = 1231;

		// Token: 0x0400015D RID: 349
		public static Shirt TrashCanShirt = 1232;

		// Token: 0x0400015E RID: 350
		public static Shirt RustyShirt = 1233;

		// Token: 0x0400015F RID: 351
		public static Shirt CircuitboardShirt = 1234;

		// Token: 0x04000160 RID: 352
		public static Shirt FluffyShirt = 1235;

		// Token: 0x04000161 RID: 353
		public static Shirt SauceStainedShirt = 1236;

		// Token: 0x04000162 RID: 354
		public static Shirt BrownSuit = 1237;

		// Token: 0x04000163 RID: 355
		public static Shirt GoldenShirt = 1238;

		// Token: 0x04000164 RID: 356
		public static Shirt CaptainsUniform = 1239;

		// Token: 0x04000165 RID: 357
		public static Shirt OfficerUniform = 1240;

		// Token: 0x04000166 RID: 358
		public static Shirt RangerUniform = 1241;

		// Token: 0x04000167 RID: 359
		public static Shirt BlueLongVest = 1242;

		// Token: 0x04000168 RID: 360
		public static Shirt RegalMantle = 1243;

		// Token: 0x04000169 RID: 361
		public static Shirt RelicShirt = 1244;

		// Token: 0x0400016A RID: 362
		public static Shirt BoboShirt = 1245;

		// Token: 0x0400016B RID: 363
		public static Shirt FriedEggShirt = 1246;

		// Token: 0x0400016C RID: 364
		public static Shirt BurgerShirt = 1247;

		// Token: 0x0400016D RID: 365
		public static Shirt CollaredShirt = 1248;

		// Token: 0x0400016E RID: 366
		public static Shirt ToastedShirt = 1249;

		// Token: 0x0400016F RID: 367
		public static Shirt CarpShirt = 1250;

		// Token: 0x04000170 RID: 368
		public static Shirt RedFlannelShirt = 1251;

		// Token: 0x04000171 RID: 369
		public static Shirt TortillaShirt = 1252;

		// Token: 0x04000172 RID: 370
		public static Shirt WarmFlannelShirt = 1253;

		// Token: 0x04000173 RID: 371
		public static Shirt SugarShirt = 1254;

		// Token: 0x04000174 RID: 372
		public static Shirt GreenFlannelShirt = 1255;

		// Token: 0x04000175 RID: 373
		public static Shirt OilStainedShirt = 1256;

		// Token: 0x04000176 RID: 374
		public static Shirt MorelShirt = 1257;

		// Token: 0x04000177 RID: 375
		public static Shirt SpringShirt = 1258;

		// Token: 0x04000178 RID: 376
		public static Shirt SailorShirt_2 = 1259;

		// Token: 0x04000179 RID: 377
		public static Shirt RainCoat = 1260;

		// Token: 0x0400017A RID: 378
		public static Shirt SailorShirt_Dyeable_WhiteCollar = 1261;

		// Token: 0x0400017B RID: 379
		public static Shirt DarkBandanaShirt = 1262;

		// Token: 0x0400017C RID: 380
		public static Shirt DarkHighlightShirt = 1263;

		// Token: 0x0400017D RID: 381
		public static Shirt OmniShirt = 1264;

		// Token: 0x0400017E RID: 382
		public static Shirt BridalShirt = 1265;

		// Token: 0x0400017F RID: 383
		public static Shirt BrownOveralls = 1266;

		// Token: 0x04000180 RID: 384
		public static Shirt OrangeBowShirt = 1267;

		// Token: 0x04000181 RID: 385
		public static Shirt WhiteOveralls = 1268;

		// Token: 0x04000182 RID: 386
		public static Shirt PourOverShirt = 1269;

		// Token: 0x04000183 RID: 387
		public static Shirt GreenJacketShirt = 1270;

		// Token: 0x04000184 RID: 388
		public static Shirt ShortJacket = 1271;

		// Token: 0x04000185 RID: 389
		public static Shirt PolkaDotShirt = 1272;

		// Token: 0x04000186 RID: 390
		public static Shirt WhiteDotShirt = 1273;

		// Token: 0x04000187 RID: 391
		public static Shirt CamoShirt = 1274;

		// Token: 0x04000188 RID: 392
		public static Shirt DirtShirt = 1275;

		// Token: 0x04000189 RID: 393
		public static Shirt CrabCakeShirt = 1276;

		// Token: 0x0400018A RID: 394
		public static Shirt SilkyShirt = 1277;

		// Token: 0x0400018B RID: 395
		public static Shirt BlueButtonedVest = 1278;

		// Token: 0x0400018C RID: 396
		public static Shirt FadedDenimShirt = 1279;

		// Token: 0x0400018D RID: 397
		public static Shirt RedButtonedVest = 1280;

		// Token: 0x0400018E RID: 398
		public static Shirt GreenButtonedVest = 1281;

		// Token: 0x0400018F RID: 399
		public static Shirt TomatoShirt = 1282;

		// Token: 0x04000190 RID: 400
		public static Shirt FringedVest = 1283;

		// Token: 0x04000191 RID: 401
		public static Shirt GlobbyShirt = 1284;

		// Token: 0x04000192 RID: 402
		public static Shirt MidnightDogJacket = 1285;

		// Token: 0x04000193 RID: 403
		public static Shirt ShrimpEnthusiastShirt = 1286;

		// Token: 0x04000194 RID: 404
		public static Shirt TeaShirt = 1287;

		// Token: 0x04000195 RID: 405
		public static Shirt TrinketShirt = 1288;

		// Token: 0x04000196 RID: 406
		public static Shirt DarknessSuit = 1289;

		// Token: 0x04000197 RID: 407
		public static Shirt MineralDogJacket = 1290;

		// Token: 0x04000198 RID: 408
		public static Shirt MagentaShirt = 1291;

		// Token: 0x04000199 RID: 409
		public static Shirt GingerOveralls = 1292;

		// Token: 0x0400019A RID: 410
		public static Shirt BananaShirt = 1293;

		// Token: 0x0400019B RID: 411
		public static Shirt YellowSuit = 1294;

		// Token: 0x0400019C RID: 412
		public static Shirt HotPinkShirt = 1295;

		// Token: 0x0400019D RID: 413
		public static Shirt TropicalSunriseShirt = 1296;

		// Token: 0x0400019E RID: 414
		public static Shirt IslandBikini = 1297;

		// Token: 0x0400019F RID: 415
		public static Shirt MagicSprinkleShirt = 1997;

		// Token: 0x040001A0 RID: 416
		public static Shirt PrismaticShirt_DarkSleeves = 1998;

		// Token: 0x040001A1 RID: 417
		public static Shirt PrismaticShirt_WhiteSleeves = 1999;

		// Token: 0x040001A2 RID: 418
		private static Dictionary<string, Shirt> lut_ids = new Dictionary<string, Shirt>();

		// Token: 0x040001A3 RID: 419
		private static Dictionary<string, Shirt> lut_names = new Dictionary<string, Shirt>();
	}
}
