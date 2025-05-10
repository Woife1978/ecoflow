// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

public class ChannelPowerInfoList
    {
        public int powType { get; set; }
        public double chWatt { get; set; }
    }

    public class EmergencyStrategyChStum
    {
        public int priority { get; set; }
        public int isEnable { get; set; }
    }

    public class HeartbeatBackupCmdChCtrlInfo
    {
        public int powCh { get; set; }
        public int ctrlSta { get; set; }
        public int ctrlMode { get; set; }
        public int priority { get; set; }
    }

    public class HeartbeatEnergyInfo
    {
        public int dischargeTime { get; set; }
        public int mulPackNum { get; set; }
        public StateBean stateBean { get; set; }
        public double outputPower { get; set; }
        public int lcdInputWatts { get; set; }
        public double fullCap { get; set; }
        public int chargeTime { get; set; }
        public int emsChgFlag { get; set; }
        public int type { get; set; }
        public int emsBatTemp { get; set; }
        public double ratePower { get; set; }
        public int batteryPercentage { get; set; }
        public int oilPackNum { get; set; }
    }

    public class HeartbeatLoadCmdChCtrlInfo
    {
        public int powCh { get; set; }
        public int ctrlSta { get; set; }
        public int ctrlMode { get; set; }
        public int priority { get; set; }
    }

    public class Info
    {
        public int iconNum { get; set; }
        public string chName { get; set; }
    }

    public class LoadChInfo
    {
        public List<Info> info { get; set; }
    }

    public class SmartHomePanel
    {
        [JsonProperty("heartbeat.errorCodes")]
        public List<int> heartbeaterrorCodes { get; set; }

        [JsonProperty("backupLoadWatt.rtc")]
        public string backupLoadWattrtc { get; set; }

        [JsonProperty("cfgSta.sta")]
        public int cfgStasta { get; set; }

        [JsonProperty("heartbeat.backupCmdChCtrlInfos")]
        public List<HeartbeatBackupCmdChCtrlInfo> heartbeatbackupCmdChCtrlInfos { get; set; }

        [JsonProperty("chUseInfo.cmdSet")]
        public int chUseInfocmdSet { get; set; }

        [JsonProperty("heartbeat.id")]
        public int heartbeatid { get; set; }

        [JsonProperty("backupChaDiscCfg.id")]
        public int backupChaDiscCfgid { get; set; }

        [JsonProperty("selfCheck.id")]
        public int selfCheckid { get; set; }

        [JsonProperty("splitPhaseInfo.id")]
        public int splitPhaseInfoid { get; set; }

        [JsonProperty("channelPower.time.min")]
        public int channelPowertimemin { get; set; }

        [JsonProperty("channelPower.time.sec")]
        public int channelPowertimesec { get; set; }

        [JsonProperty("selfCheck.vOut")]
        public List<double> selfCheckvOut { get; set; }

        [JsonProperty("selfCheck.cmdSet")]
        public int selfCheckcmdSet { get; set; }

        [JsonProperty("loadChCurInfo.cur")]
        public List<int> loadChCurInfocur { get; set; }

        [JsonProperty("backupLoadWatt.cmdSet")]
        public int backupLoadWattcmdSet { get; set; }

        [JsonProperty("topupLoadWatt.rtc")]
        public string topupLoadWattrtc { get; set; }

        [JsonProperty("heartbeat.backupFullCap")]
        public int heartbeatbackupFullCap { get; set; }

        [JsonProperty("channelPower.cmdSet")]
        public int channelPowercmdSet { get; set; }

        [JsonProperty("heartbeat.loadCmdChCtrlInfos")]
        public List<HeartbeatLoadCmdChCtrlInfo> heartbeatloadCmdChCtrlInfos { get; set; }
        public LoadChInfo loadChInfo { get; set; }

        [JsonProperty("topupLoadWatt.watth")]
        public List<List<int>> topupLoadWattwatth { get; set; }

        [JsonProperty("chUseInfo.id")]
        public int chUseInfoid { get; set; }

        [JsonProperty("backupLoadWatt.id")]
        public int backupLoadWattid { get; set; }

        [JsonProperty("heartbeat.time.month")]
        public int heartbeattimemonth { get; set; }

        [JsonProperty("gridInfo.gridFreq")]
        public int gridInfogridFreq { get; set; }

        [JsonProperty("areaInfo.cmdSet")]
        public int areaInfocmdSet { get; set; }

        [JsonProperty("channelPower.time.week")]
        public int channelPowertimeweek { get; set; }

        [JsonProperty("channelPower.time.month")]
        public int channelPowertimemonth { get; set; }

        [JsonProperty("gridInfo.gridVol")]
        public int gridInfogridVol { get; set; }

        [JsonProperty("cfgSta.id")]
        public int cfgStaid { get; set; }

        [JsonProperty("areaInfo.area")]
        public string areaInfoarea { get; set; }

        [JsonProperty("selfCheck.chErrorSta")]
        public List<int> selfCheckchErrorSta { get; set; }

        [JsonProperty("emergencyStrategy.chSta")]
        public List<EmergencyStrategyChStum> emergencyStrategychSta { get; set; }

        [JsonProperty("selfCheck.phaseType")]
        public List<int> selfCheckphaseType { get; set; }

        [JsonProperty("emergencyStrategy.id")]
        public int emergencyStrategyid { get; set; }

        [JsonProperty("gridInfo.cmdSet")]
        public int gridInfocmdSet { get; set; }

        [JsonProperty("heartbeat.mm100Sn")]
        public List<int> heartbeatmm100Sn { get; set; }

        [JsonProperty("loadChCurInfo.cmdSet")]
        public int loadChCurInfocmdSet { get; set; }

        [JsonProperty("heartbeat.time.sec")]
        public int heartbeattimesec { get; set; }

        [JsonProperty("selfCheck.vIn")]
        public List<double> selfCheckvIn { get; set; }

        [JsonProperty("heartbeat.time.min")]
        public int heartbeattimemin { get; set; }

        [JsonProperty("mainsLoadWatt.watth")]
        public List<List<int>> mainsLoadWattwatth { get; set; }

        [JsonProperty("heartbeat.time.week")]
        public int heartbeattimeweek { get; set; }

        [JsonProperty("backupChaDiscCfg.forceChargeHigh")]
        public int backupChaDiscCfgforceChargeHigh { get; set; }

        [JsonProperty("topupLoadWatt.cmdSet")]
        public int topupLoadWattcmdSet { get; set; }

        [JsonProperty("emergencyStrategy.backupMode")]
        public int emergencyStrategybackupMode { get; set; }

        [JsonProperty("cfgSta.cmdSet")]
        public int cfgStacmdSet { get; set; }

        [JsonProperty("heartbeat.time.hour")]
        public int heartbeattimehour { get; set; }

        [JsonProperty("emergencyStrategy.isCfg")]
        public int emergencyStrategyisCfg { get; set; }

        [JsonProperty("splitPhaseInfo.cfgList")]
        public List<SplitPhaseInfoCfgList> splitPhaseInfocfgList { get; set; }

        [JsonProperty("emergencyStrategy.cmdSet")]
        public int emergencyStrategycmdSet { get; set; }

        [JsonProperty("selfCheck.result")]
        public int selfCheckresult { get; set; }

        [JsonProperty("mainsLoadWatt.cmdSet")]
        public int mainsLoadWattcmdSet { get; set; }

        [JsonProperty("epsModeInfo.eps")]
        public bool epsModeInfoeps { get; set; }

        [JsonProperty("areaInfo.id")]
        public int areaInfoid { get; set; }

        [JsonProperty("channelPower.id")]
        public int channelPowerid { get; set; }

        [JsonProperty("splitPhaseInfo.cmdSet")]
        public int splitPhaseInfocmdSet { get; set; }

        [JsonProperty("heartbeat.cmdSet")]
        public int heartbeatcmdSet { get; set; }

        [JsonProperty("heartbeat.timezoneInfo.timezone")]
        public int heartbeattimezoneInfotimezone { get; set; }

        [JsonProperty("backupChaDiscCfg.cmdSet")]
        public int backupChaDiscCfgcmdSet { get; set; }

        [JsonProperty("channelPower.infoList")]
        public List<ChannelPowerInfoList> channelPowerinfoList { get; set; }

        [JsonProperty("heartbeat.gridDayWatth")]
        public double heartbeatgridDayWatth { get; set; }

        [JsonProperty("mainsLoadWatt.rtc")]
        public string mainsLoadWattrtc { get; set; }

        [JsonProperty("gridInfo.id")]
        public int gridInfoid { get; set; }

        [JsonProperty("heartbeat.backupChaTime")]
        public int heartbeatbackupChaTime { get; set; }

        [JsonProperty("epsModeInfo.cmdSet")]
        public int epsModeInfocmdSet { get; set; }

        [JsonProperty("emergencyStrategy.overloadMode")]
        public int emergencyStrategyoverloadMode { get; set; }

        [JsonProperty("channelPower.time.hour")]
        public int channelPowertimehour { get; set; }

        [JsonProperty("heartbeat.backupDayWatth")]
        public double heartbeatbackupDayWatth { get; set; }

        [JsonProperty("selfCheck.flag")]
        public int selfCheckflag { get; set; }

        [JsonProperty("heartbeat.backupBatPer")]
        public int heartbeatbackupBatPer { get; set; }

        [JsonProperty("chUseInfo.isEnable")]
        public List<bool> chUseInfoisEnable { get; set; }

        [JsonProperty("backupChaDiscCfg.discLower")]
        public int backupChaDiscCfgdiscLower { get; set; }

        [JsonProperty("channelPower.time.day")]
        public int channelPowertimeday { get; set; }

        [JsonProperty("heartbeat.energyInfos")]
        public List<HeartbeatEnergyInfo> heartbeatenergyInfos { get; set; }

        [JsonProperty("channelPower.time.year")]
        public int channelPowertimeyear { get; set; }

        [JsonProperty("epsModeInfo.id")]
        public int epsModeInfoid { get; set; }

        [JsonProperty("heartbeat.time.year")]
        public int heartbeattimeyear { get; set; }

        [JsonProperty("selfCheck.errorCode")]
        public int selfCheckerrorCode { get; set; }

        [JsonProperty("mainsLoadWatt.id")]
        public int mainsLoadWattid { get; set; }

        [JsonProperty("topupLoadWatt.id")]
        public int topupLoadWattid { get; set; }

        [JsonProperty("heartbeat.gridSta")]
        public int heartbeatgridSta { get; set; }

        [JsonProperty("heartbeat.time.day")]
        public int heartbeattimeday { get; set; }

        [JsonProperty("backupLoadWatt.watth")]
        public List<List<int>> backupLoadWattwatth { get; set; }

        [JsonProperty("loadChCurInfo.id")]
        public int loadChCurInfoid { get; set; }

        [JsonProperty("heartbeat.workTime")]
        public long heartbeatworkTime { get; set; }
    }

    public class SplitPhaseInfoCfgList
    {
        public int linkMark { get; set; }
        public int linkCh { get; set; }
    }

    public class StateBean
    {
        public int isPowerOutput { get; set; }
        public int isConnect { get; set; }
        public int isEnable { get; set; }
        public int isGridCharge { get; set; }
        public int isMpptCharge { get; set; }
        public int isAcOpen { get; set; }
    }

