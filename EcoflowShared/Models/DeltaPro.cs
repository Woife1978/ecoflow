// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

public class KitProductInfoDetail
    {
        public int protocolAvaiFlag { get; set; }
        public string sn { get; set; }
        public int productType { get; set; }
        public int productDetail { get; set; }
        public int procedureState { get; set; }
        public int appVersion { get; set; }
        public int loaderVersion { get; set; }
        public int curPower { get; set; }
        public double f32Soc { get; set; }
        public int soc { get; set; }
    }

    public class DeltaPro
    {
        [JsonProperty("pd.iconWifiMode")]
        public int pdiconWifiMode { get; set; }

        [JsonProperty("mppt.faultCode")]
        public int mpptfaultCode { get; set; }

        [JsonProperty("ems.minDsgSoc")]
        public int emsminDsgSoc { get; set; }

        [JsonProperty("bmsSlave2.designCap")]
        public int bmsSlave2designCap { get; set; }

        [JsonProperty("pd.iconOverloadState")]
        public int pdiconOverloadState { get; set; }

        [JsonProperty("pd.watthisconfig")]
        public int pdwatthisconfig { get; set; }

        [JsonProperty("bmsMaster.totalDsgCap")]
        public long bmsMastertotalDsgCap { get; set; }

        [JsonProperty("bmsSlave2.chgDsgState")]
        public int bmsSlave2chgDsgState { get; set; }

        [JsonProperty("ems.emsIsNormalFlag")]
        public int emsemsIsNormalFlag { get; set; }

        [JsonProperty("inv.cfgAcOutVoltage")]
        public int invcfgAcOutVoltage { get; set; }

        [JsonProperty("bmsSlave2.openBmsIdx")]
        public int bmsSlave2openBmsIdx { get; set; }

        [JsonProperty("bmsMaster.bmsHeartbeatVer")]
        public int bmsMasterbmsHeartbeatVer { get; set; }

        [JsonProperty("pd.iconGasGenMode")]
        public int pdiconGasGenMode { get; set; }

        [JsonProperty("bmsSlave2.totalDsgCap")]
        public long bmsSlave2totalDsgCap { get; set; }

        [JsonProperty("pd.iconBmsParallelMode")]
        public int pdiconBmsParallelMode { get; set; }

        [JsonProperty("bmsSlave2.balanceState")]
        public int bmsSlave2balanceState { get; set; }

        [JsonProperty("pd.iconCoGasState")]
        public int pdiconCoGasState { get; set; }

        [JsonProperty("bmsMaster.chgDsgState")]
        public int bmsMasterchgDsgState { get; set; }

        [JsonProperty("inv.invOutFreq")]
        public int invinvOutFreq { get; set; }

        [JsonProperty("inv.cfgFastChgWatts")]
        public int invcfgFastChgWatts { get; set; }

        [JsonProperty("bmsMaster.bqSysStatReg")]
        public int bmsMasterbqSysStatReg { get; set; }

        [JsonProperty("mppt.inAmp")]
        public int mpptinAmp { get; set; }

        [JsonProperty("bmsSlave2.num")]
        public int bmsSlave2num { get; set; }

        [JsonProperty("bmsMaster.errCode")]
        public int bmsMastererrCode { get; set; }

        [JsonProperty("pd.usb1Watts")]
        public int pdusb1Watts { get; set; }

        [JsonProperty("bmsSlave2.soc")]
        public int bmsSlave2soc { get; set; }

        [JsonProperty("inv.cfgAcXboost")]
        public int invcfgAcXboost { get; set; }

        [JsonProperty("inv.outTemp")]
        public int invoutTemp { get; set; }

        [JsonProperty("bmsMaster.balanceState")]
        public int bmsMasterbalanceState { get; set; }

        [JsonProperty("bmsMaster.ecloudOcv")]
        public int bmsMasterecloudOcv { get; set; }

        [JsonProperty("pd.chgPowerDc")]
        public int pdchgPowerDc { get; set; }

        [JsonProperty("mppt.dcdc12vAmp")]
        public int mpptdcdc12vAmp { get; set; }

        [JsonProperty("pd.iconUsbState")]
        public int pdiconUsbState { get; set; }

        [JsonProperty("bmsSlave2.mosState")]
        public int bmsSlave2mosState { get; set; }

        [JsonProperty("ems.dsgCmd")]
        public int emsdsgCmd { get; set; }

        [JsonProperty("pd.extRj45Port")]
        public int pdextRj45Port { get; set; }

        [JsonProperty("bmsMaster.remainTime")]
        public int bmsMasterremainTime { get; set; }

        [JsonProperty("inv.inputWatts")]
        public int invinputWatts { get; set; }

        [JsonProperty("bmsMaster.fullCap")]
        public int bmsMasterfullCap { get; set; }

        [JsonProperty("pd.iconBtMode")]
        public int pdiconBtMode { get; set; }

        [JsonProperty("bmsMaster.maxVolDiff")]
        public int bmsMastermaxVolDiff { get; set; }

        [JsonProperty("pd.typec2Temp")]
        public int pdtypec2Temp { get; set; }

        [JsonProperty("pd.typec1Watts")]
        public int pdtypec1Watts { get; set; }

        [JsonProperty("bmsMaster.hwEdition")]
        public List<int> bmsMasterhwEdition { get; set; }

        [JsonProperty("pd.soc")]
        public int pdsoc { get; set; }

        [JsonProperty("pd.iconFactoryState")]
        public int pdiconFactoryState { get; set; }

        [JsonProperty("inv.invOutAmp")]
        public int invinvOutAmp { get; set; }

        [JsonProperty("pd.iconChgStationState")]
        public int pdiconChgStationState { get; set; }

        [JsonProperty("ems.chgAmp")]
        public int emschgAmp { get; set; }

        [JsonProperty("ems.bms2Online")]
        public int emsbms2Online { get; set; }

        [JsonProperty("bmsMaster.remainCap")]
        public int bmsMasterremainCap { get; set; }

        [JsonProperty("ems.paraVolMax")]
        public int emsparaVolMax { get; set; }

        [JsonProperty("pd.iconCarState")]
        public int pdiconCarState { get; set; }

        [JsonProperty("pd.ext3p8Port")]
        public int pdext3p8Port { get; set; }

        [JsonProperty("bmsSlave2.maxVolDiff")]
        public int bmsSlave2maxVolDiff { get; set; }

        [JsonProperty("bmsSlave2.minCellTemp")]
        public int bmsSlave2minCellTemp { get; set; }

        [JsonProperty("inv.dcInAmp")]
        public int invdcInAmp { get; set; }

        [JsonProperty("mppt.carOutAmp")]
        public int mpptcarOutAmp { get; set; }

        [JsonProperty("bmsMaster.vol")]
        public int bmsMastervol { get; set; }

        [JsonProperty("bmsSlave2.cellId")]
        public int bmsSlave2cellId { get; set; }

        [JsonProperty("bmsSlave2.type")]
        public int bmsSlave2type { get; set; }

        [JsonProperty("bmsSlave2.bmsHeartbeatVer")]
        public int bmsSlave2bmsHeartbeatVer { get; set; }

        [JsonProperty("bmsMaster.cellSeriesNum")]
        public int bmsMastercellSeriesNum { get; set; }

        [JsonProperty("pd.iconWifiState")]
        public int pdiconWifiState { get; set; }

        [JsonProperty("bmsMaster.type")]
        public int bmsMastertype { get; set; }

        [JsonProperty("inv.cfgAcEnabled")]
        public int invcfgAcEnabled { get; set; }

        [JsonProperty("bmsSlave2.diffSoc")]
        public double bmsSlave2diffSoc { get; set; }

        [JsonProperty("bmsSlave2.cellNtcNum")]
        public int bmsSlave2cellNtcNum { get; set; }

        [JsonProperty("bmsMaster.sysState")]
        public int bmsMastersysState { get; set; }

        [JsonProperty("mppt.chgType")]
        public int mpptchgType { get; set; }

        [JsonProperty("bmsMaster.mosState")]
        public int bmsMastermosState { get; set; }

        [JsonProperty("pd.iconBmsErrState")]
        public int pdiconBmsErrState { get; set; }

        [JsonProperty("bmsSlave2.packSn")]
        public List<int> bmsSlave2packSn { get; set; }

        [JsonProperty("mppt.cfgChgType")]
        public int mpptcfgChgType { get; set; }

        [JsonProperty("pd.iconBmsErrMode")]
        public int pdiconBmsErrMode { get; set; }

        [JsonProperty("inv.acPassByAutoEn")]
        public int invacPassByAutoEn { get; set; }

        [JsonProperty("pd.iconEcoState")]
        public int pdiconEcoState { get; set; }

        [JsonProperty("inv.dischargeType")]
        public int invdischargeType { get; set; }

        [JsonProperty("pd.carState")]
        public int pdcarState { get; set; }

        [JsonProperty("pd.invUsedTime")]
        public int pdinvUsedTime { get; set; }

        [JsonProperty("pd.iconAcFreqMode")]
        public int pdiconAcFreqMode { get; set; }

        [JsonProperty("bmsSlave2.inputWatts")]
        public int bmsSlave2inputWatts { get; set; }

        [JsonProperty("ems.f32LcdShowSoc")]
        public double emsf32LcdShowSoc { get; set; }

        [JsonProperty("mppt.carTemp")]
        public int mpptcarTemp { get; set; }

        [JsonProperty("pd.chgPowerAc")]
        public int pdchgPowerAc { get; set; }

        [JsonProperty("mppt.outWatts")]
        public int mpptoutWatts { get; set; }

        [JsonProperty("pd.beepState")]
        public int pdbeepState { get; set; }

        [JsonProperty("pd.iconPackHeaterState")]
        public int pdiconPackHeaterState { get; set; }

        [JsonProperty("pd.wifiAutoRcvy")]
        public int pdwifiAutoRcvy { get; set; }

        [JsonProperty("bmsSlave2.allBmsFault")]
        public int bmsSlave2allBmsFault { get; set; }

        [JsonProperty("pd.remainTime")]
        public int pdremainTime { get; set; }

        [JsonProperty("bmsSlave2.vol")]
        public int bmsSlave2vol { get; set; }

        [JsonProperty("bmsMaster.maxCellTemp")]
        public int bmsMastermaxCellTemp { get; set; }

        [JsonProperty("pd.relayswitchcnt")]
        public int pdrelayswitchcnt { get; set; }

        [JsonProperty("ems.maxChargeSoc")]
        public int emsmaxChargeSoc { get; set; }

        [JsonProperty("mppt.outAmp")]
        public int mpptoutAmp { get; set; }

        [JsonProperty("pd.ext4p8Port")]
        public int pdext4p8Port { get; set; }

        [JsonProperty("mppt.chgPauseFlag")]
        public int mpptchgPauseFlag { get; set; }

        [JsonProperty("inv.chargerType")]
        public int invchargerType { get; set; }

        [JsonProperty("pd.chgSunPower")]
        public int pdchgSunPower { get; set; }

        [JsonProperty("pd.lcdBrightness")]
        public int pdlcdBrightness { get; set; }

        [JsonProperty("pd.iconRechgTimeState")]
        public int pdiconRechgTimeState { get; set; }

        [JsonProperty("bmsSlave2.sysState")]
        public int bmsSlave2sysState { get; set; }

        [JsonProperty("bmsMaster.maxMosTemp")]
        public int bmsMastermaxMosTemp { get; set; }

        [JsonProperty("pd.lcdOffSec")]
        public int pdlcdOffSec { get; set; }

        [JsonProperty("pd.iconTransSwState")]
        public int pdiconTransSwState { get; set; }

        [JsonProperty("bmsSlave2.targetSoc")]
        public double bmsSlave2targetSoc { get; set; }

        [JsonProperty("pd.iconTypecMode")]
        public int pdiconTypecMode { get; set; }

        [JsonProperty("inv.acInVol")]
        public int invacInVol { get; set; }

        [JsonProperty("ems.openUpsFlag")]
        public int emsopenUpsFlag { get; set; }

        [JsonProperty("pd.sysVer")]
        public int pdsysVer { get; set; }

        [JsonProperty("pd.iconOverloadMode")]
        public int pdiconOverloadMode { get; set; }

        [JsonProperty("mppt.dc24vTemp")]
        public int mpptdc24vTemp { get; set; }

        [JsonProperty("bmsSlave2.remainCap")]
        public int bmsSlave2remainCap { get; set; }

        [JsonProperty("ems.bmsWarningState")]
        public int emsbmsWarningState { get; set; }

        [JsonProperty("bmsMaster.cellVol")]
        public List<int> bmsMastercellVol { get; set; }

        [JsonProperty("bmsSlave2.temp")]
        public int bmsSlave2temp { get; set; }

        [JsonProperty("mppt.xt60ChgType")]
        public int mpptxt60ChgType { get; set; }

        [JsonProperty("bmsSlave2.productDetail")]
        public int bmsSlave2productDetail { get; set; }

        [JsonProperty("bmsMaster.cellNtcNum")]
        public int bmsMastercellNtcNum { get; set; }

        [JsonProperty("bmsSlave2.errCode")]
        public int bmsSlave2errCode { get; set; }

        [JsonProperty("pd.acautooutPause")]
        public int pdacautooutPause { get; set; }

        [JsonProperty("pd.iconFactoryMode")]
        public int pdiconFactoryMode { get; set; }

        [JsonProperty("ems.bms0Online")]
        public int emsbms0Online { get; set; }

        [JsonProperty("inv.cfgAcOutFreq")]
        public int invcfgAcOutFreq { get; set; }

        [JsonProperty("pd.iconFanMode")]
        public int pdiconFanMode { get; set; }

        [JsonProperty("inv.errCode")]
        public int inverrCode { get; set; }

        [JsonProperty("mppt.dcdc12vWatts")]
        public int mpptdcdc12vWatts { get; set; }

        [JsonProperty("pd.dcOutState")]
        public int pddcOutState { get; set; }

        [JsonProperty("mppt.cfgDcChgCurrent")]
        public int mpptcfgDcChgCurrent { get; set; }

        [JsonProperty("ems.dsgRemainTime")]
        public int emsdsgRemainTime { get; set; }

        [JsonProperty("bmsMaster.openBmsIdx")]
        public int bmsMasteropenBmsIdx { get; set; }

        [JsonProperty("pd.mpptUsedTime")]
        public int pdmpptUsedTime { get; set; }

        [JsonProperty("ems.maxAvailableNum")]
        public int emsmaxAvailableNum { get; set; }

        [JsonProperty("bmsMaster.realSoh")]
        public double bmsMasterrealSoh { get; set; }

        [JsonProperty("mppt.mpptTemp")]
        public int mpptmpptTemp { get; set; }

        [JsonProperty("pd.iconWirelessChgMode")]
        public int pdiconWirelessChgMode { get; set; }

        [JsonProperty("pd.wifiRssi")]
        public int pdwifiRssi { get; set; }

        [JsonProperty("ems.bms1Online")]
        public int emsbms1Online { get; set; }

        [JsonProperty("bmsMaster.productType")]
        public int bmsMasterproductType { get; set; }

        [JsonProperty("ems.bmsModel")]
        public int emsbmsModel { get; set; }

        [JsonProperty("pd.iconSolarBracketState")]
        public int pdiconSolarBracketState { get; set; }

        [JsonProperty("kit.maxKitNum")]
        public int kitmaxKitNum { get; set; }

        [JsonProperty("bmsMaster.minCellVol")]
        public int bmsMasterminCellVol { get; set; }

        [JsonProperty("pd.iconCoGasMode")]
        public int pdiconCoGasMode { get; set; }

        [JsonProperty("pd.iconChgStationMode")]
        public int pdiconChgStationMode { get; set; }

        [JsonProperty("pd.iconGasGenState")]
        public int pdiconGasGenState { get; set; }

        [JsonProperty("pd.usb2Watts")]
        public int pdusb2Watts { get; set; }

        [JsonProperty("pd.iconRcMode")]
        public int pdiconRcMode { get; set; }

        [JsonProperty("inv.cfgSlowChgWatts")]
        public int invcfgSlowChgWatts { get; set; }

        [JsonProperty("bmsSlave2.f32ShowSoc")]
        public double bmsSlave2f32ShowSoc { get; set; }

        [JsonProperty("bmsMaster.f32ShowSoc")]
        public double bmsMasterf32ShowSoc { get; set; }

        [JsonProperty("bmsSlave2.minMosTemp")]
        public int bmsSlave2minMosTemp { get; set; }

        [JsonProperty("mppt.dc24vState")]
        public int mpptdc24vState { get; set; }

        [JsonProperty("pd.wattsInSum")]
        public int pdwattsInSum { get; set; }

        [JsonProperty("bmsSlave2.maxCellVol")]
        public int bmsSlave2maxCellVol { get; set; }

        [JsonProperty("pd.wifiVer")]
        public int pdwifiVer { get; set; }

        [JsonProperty("pd.iconLowTempMode")]
        public int pdiconLowTempMode { get; set; }

        [JsonProperty("inv.cfgAcWorkMode")]
        public int invcfgAcWorkMode { get; set; }

        [JsonProperty("bmsSlave2.maxMosTemp")]
        public int bmsSlave2maxMosTemp { get; set; }

        [JsonProperty("bmsSlave2.cellSeriesNum")]
        public int bmsSlave2cellSeriesNum { get; set; }

        [JsonProperty("bmsMaster.bmsFault")]
        public int bmsMasterbmsFault { get; set; }

        [JsonProperty("bmsMaster.diffSoc")]
        public double bmsMasterdiffSoc { get; set; }

        [JsonProperty("pd.iconInvParallelState")]
        public int pdiconInvParallelState { get; set; }

        [JsonProperty("pd.typec2Watts")]
        public int pdtypec2Watts { get; set; }

        [JsonProperty("pd.iconTypecState")]
        public int pdiconTypecState { get; set; }

        [JsonProperty("pd.iconCarMode")]
        public int pdiconCarMode { get; set; }

        [JsonProperty("inv.outputWatts")]
        public int invoutputWatts { get; set; }

        [JsonProperty("bmsMaster.soh")]
        public int bmsMastersoh { get; set; }

        [JsonProperty("bmsSlave2.calendarSch")]
        public double bmsSlave2calendarSch { get; set; }

        [JsonProperty("pd.iconRcState")]
        public int pdiconRcState { get; set; }

        [JsonProperty("bmsMaster.calendarSch")]
        public double bmsMastercalendarSch { get; set; }

        [JsonProperty("bmsSlave2.outputWatts")]
        public int bmsSlave2outputWatts { get; set; }

        [JsonProperty("kit.availableDataLen")]
        public int kitavailableDataLen { get; set; }

        [JsonProperty("kit.productInfoDetails")]
        public List<KitProductInfoDetail> kitproductInfoDetails { get; set; }

        [JsonProperty("bmsSlave2.minCellVol")]
        public int bmsSlave2minCellVol { get; set; }

        [JsonProperty("bmsSlave2.cellTemp")]
        public List<int> bmsSlave2cellTemp { get; set; }

        [JsonProperty("bmsMaster.soc")]
        public int bmsMastersoc { get; set; }

        [JsonProperty("bmsMaster.num")]
        public int bmsMasternum { get; set; }

        [JsonProperty("pd.iconHiTempState")]
        public int pdiconHiTempState { get; set; }

        [JsonProperty("mppt.inVol")]
        public int mpptinVol { get; set; }

        [JsonProperty("pd.iconHiTempMode")]
        public int pdiconHiTempMode { get; set; }

        [JsonProperty("pd.iconEcoMode")]
        public int pdiconEcoMode { get; set; }

        [JsonProperty("inv.fanState")]
        public int invfanState { get; set; }

        [JsonProperty("pd.standByMode")]
        public int pdstandByMode { get; set; }

        [JsonProperty("bmsMaster.cellTemp")]
        public List<int> bmsMastercellTemp { get; set; }

        [JsonProperty("bmsSlave2.totalChgCap")]
        public long bmsSlave2totalChgCap { get; set; }

        [JsonProperty("ems.chgVol")]
        public int emschgVol { get; set; }

        [JsonProperty("pd.dsgPowerDc")]
        public int pddsgPowerDc { get; set; }

        [JsonProperty("bmsMaster.inputWatts")]
        public int bmsMasterinputWatts { get; set; }

        [JsonProperty("pd.typccUsedTime")]
        public int pdtypccUsedTime { get; set; }

        [JsonProperty("inv.invOutVol")]
        public int invinvOutVol { get; set; }

        [JsonProperty("ems.chgState")]
        public int emschgState { get; set; }

        [JsonProperty("pd.carUsedTime")]
        public int pdcarUsedTime { get; set; }

        [JsonProperty("inv.acInFreq")]
        public int invacInFreq { get; set; }

        [JsonProperty("inv.chgPauseFlag")]
        public int invchgPauseFlag { get; set; }

        [JsonProperty("pd.minAcoutSoc")]
        public int pdminAcoutSoc { get; set; }

        [JsonProperty("ems.fanLevel")]
        public int emsfanLevel { get; set; }

        [JsonProperty("pd.iconBmsParallelState")]
        public int pdiconBmsParallelState { get; set; }

        [JsonProperty("pd.wirelessWatts")]
        public int pdwirelessWatts { get; set; }

        [JsonProperty("bmsSlave2.sysLoaderVer")]
        public int bmsSlave2sysLoaderVer { get; set; }

        [JsonProperty("mppt.carOutVol")]
        public int mpptcarOutVol { get; set; }

        [JsonProperty("pd.iconSocUpsMode")]
        public int pdiconSocUpsMode { get; set; }

        [JsonProperty("inv.dcInVol")]
        public int invdcInVol { get; set; }

        [JsonProperty("bmsSlave2.productType")]
        public int bmsSlave2productType { get; set; }

        [JsonProperty("bmsSlave2.fullCap")]
        public int bmsSlave2fullCap { get; set; }

        [JsonProperty("bmsSlave2.sysVer")]
        public int bmsSlave2sysVer { get; set; }

        [JsonProperty("pd.iconSolarBracketMode")]
        public int pdiconSolarBracketMode { get; set; }

        [JsonProperty("bmsSlave2.cycles")]
        public int bmsSlave2cycles { get; set; }

        [JsonProperty("ems.minOpenOilEbSoc")]
        public int emsminOpenOilEbSoc { get; set; }

        [JsonProperty("bmsMaster.packSn")]
        public List<int> bmsMasterpackSn { get; set; }

        [JsonProperty("ems.paraVolMin")]
        public int emsparaVolMin { get; set; }

        [JsonProperty("inv.dcInTemp")]
        public int invdcInTemp { get; set; }

        [JsonProperty("mppt.dcdc12vVol")]
        public int mpptdcdc12vVol { get; set; }

        [JsonProperty("bmsSlave2.actSoc")]
        public double bmsSlave2actSoc { get; set; }

        [JsonProperty("bmsMaster.amp")]
        public int bmsMasteramp { get; set; }

        [JsonProperty("pd.wattsOutSum")]
        public int pdwattsOutSum { get; set; }

        [JsonProperty("pd.iconWindGenMode")]
        public int pdiconWindGenMode { get; set; }

        [JsonProperty("bmsMaster.cycleSoh")]
        public double bmsMastercycleSoh { get; set; }

        [JsonProperty("mppt.carOutWatts")]
        public int mpptcarOutWatts { get; set; }

        [JsonProperty("mppt.outVol")]
        public int mpptoutVol { get; set; }

        [JsonProperty("pd.iconUsbMode")]
        public int pdiconUsbMode { get; set; }

        [JsonProperty("bmsSlave2.bmsFault")]
        public int bmsSlave2bmsFault { get; set; }

        [JsonProperty("bmsSlave2.hwEdition")]
        public List<int> bmsSlave2hwEdition { get; set; }

        [JsonProperty("inv.acDipSwitch")]
        public int invacDipSwitch { get; set; }

        [JsonProperty("bmsMaster.totalChgCap")]
        public long bmsMastertotalChgCap { get; set; }

        [JsonProperty("pd.iconWindGenState")]
        public int pdiconWindGenState { get; set; }

        [JsonProperty("pd.iconBtState")]
        public int pdiconBtState { get; set; }

        [JsonProperty("bmsMaster.cellId")]
        public int bmsMastercellId { get; set; }

        [JsonProperty("bmsMaster.allErrCode")]
        public int bmsMasterallErrCode { get; set; }

        [JsonProperty("mppt.chgState")]
        public int mpptchgState { get; set; }

        [JsonProperty("bmsMaster.productDetail")]
        public int bmsMasterproductDetail { get; set; }

        [JsonProperty("bmsMaster.targetSoc")]
        public double bmsMastertargetSoc { get; set; }

        [JsonProperty("mppt.carState")]
        public int mpptcarState { get; set; }

        [JsonProperty("bmsMaster.designCap")]
        public int bmsMasterdesignCap { get; set; }

        [JsonProperty("pd.typec1Temp")]
        public int pdtypec1Temp { get; set; }

        [JsonProperty("bmsMaster.allBmsFault")]
        public int bmsMasterallBmsFault { get; set; }

        [JsonProperty("pd.dsgPowerAc")]
        public int pddsgPowerAc { get; set; }

        [JsonProperty("pd.dcInUsedTime")]
        public int pddcInUsedTime { get; set; }

        [JsonProperty("pd.iconLowTempState")]
        public int pdiconLowTempState { get; set; }

        [JsonProperty("pd.model")]
        public int pdmodel { get; set; }

        [JsonProperty("bmsMaster.actSoc")]
        public double bmsMasteractSoc { get; set; }

        [JsonProperty("inv.cfgStandbyMin")]
        public int invcfgStandbyMin { get; set; }

        [JsonProperty("ems.openBmsIdx")]
        public int emsopenBmsIdx { get; set; }

        [JsonProperty("pd.iconFanState")]
        public int pdiconFanState { get; set; }

        [JsonProperty("bmsMaster.sysVer")]
        public int bmsMastersysVer { get; set; }

        [JsonProperty("pd.hysteresisAdd")]
        public int pdhysteresisAdd { get; set; }

        [JsonProperty("bmsSlave2.maxCellTemp")]
        public int bmsSlave2maxCellTemp { get; set; }

        [JsonProperty("pd.carTemp")]
        public int pdcarTemp { get; set; }

        [JsonProperty("inv.acInAmp")]
        public int invacInAmp { get; set; }

        [JsonProperty("pd.acautooutConfig")]
        public int pdacautooutConfig { get; set; }

        [JsonProperty("bmsSlave2.tagChgAmp")]
        public int bmsSlave2tagChgAmp { get; set; }

        [JsonProperty("pd.qcUsb2Watts")]
        public int pdqcUsb2Watts { get; set; }

        [JsonProperty("bmsMaster.maxCellVol")]
        public int bmsMastermaxCellVol { get; set; }

        [JsonProperty("bmsMaster.minMosTemp")]
        public int bmsMasterminMosTemp { get; set; }

        [JsonProperty("bmsSlave2.cycleSoh")]
        public double bmsSlave2cycleSoh { get; set; }

        [JsonProperty("pd.iconRechgTimeMode")]
        public int pdiconRechgTimeMode { get; set; }

        [JsonProperty("bmsMaster.cycles")]
        public int bmsMastercycles { get; set; }

        [JsonProperty("kit.protocolVersion")]
        public int kitprotocolVersion { get; set; }

        [JsonProperty("pd.sysChgDsgState")]
        public int pdsysChgDsgState { get; set; }

        [JsonProperty("pd.iconInvParallelMode")]
        public int pdiconInvParallelMode { get; set; }

        [JsonProperty("ems.chgCmd")]
        public int emschgCmd { get; set; }

        [JsonProperty("pd.bppowerSoc")]
        public int pdbppowerSoc { get; set; }

        [JsonProperty("pd.qcUsb1Watts")]
        public int pdqcUsb1Watts { get; set; }

        [JsonProperty("bmsMaster.temp")]
        public int bmsMastertemp { get; set; }

        [JsonProperty("pd.iconTransSwMode")]
        public int pdiconTransSwMode { get; set; }

        [JsonProperty("ems.lcdShowSoc")]
        public int emslcdShowSoc { get; set; }

        [JsonProperty("pd.kit1")]
        public int pdkit1 { get; set; }

        [JsonProperty("mppt.swVer")]
        public int mpptswVer { get; set; }

        [JsonProperty("bmsSlave2.bqSysStatReg")]
        public int bmsSlave2bqSysStatReg { get; set; }

        [JsonProperty("bmsSlave2.allErrCode")]
        public int bmsSlave2allErrCode { get; set; }

        [JsonProperty("bmsSlave2.realSoh")]
        public double bmsSlave2realSoh { get; set; }

        [JsonProperty("ems.chgRemainTime")]
        public int emschgRemainTime { get; set; }

        [JsonProperty("pd.usbqcUsedTime")]
        public int pdusbqcUsedTime { get; set; }

        [JsonProperty("bmsSlave2.soh")]
        public int bmsSlave2soh { get; set; }

        [JsonProperty("mppt.inWatts")]
        public int mpptinWatts { get; set; }

        [JsonProperty("bmsMaster.outputWatts")]
        public int bmsMasteroutputWatts { get; set; }

        [JsonProperty("pd.usbUsedTime")]
        public int pdusbUsedTime { get; set; }

        [JsonProperty("bmsSlave2.amp")]
        public int bmsSlave2amp { get; set; }

        [JsonProperty("bmsMaster.minCellTemp")]
        public int bmsMasterminCellTemp { get; set; }

        [JsonProperty("bmsMaster.tagChgAmp")]
        public int bmsMastertagChgAmp { get; set; }

        [JsonProperty("pd.iconSolarPanelState")]
        public int pdiconSolarPanelState { get; set; }

        [JsonProperty("bmsSlave2.ecloudOcv")]
        public int bmsSlave2ecloudOcv { get; set; }

        [JsonProperty("bmsMaster.sysLoaderVer")]
        public int bmsMastersysLoaderVer { get; set; }

        [JsonProperty("inv.invType")]
        public int invinvType { get; set; }

        [JsonProperty("pd.iconSocUpsState")]
        public int pdiconSocUpsState { get; set; }

        [JsonProperty("pd.errCode")]
        public int pderrCode { get; set; }

        [JsonProperty("pd.iconPackHeaterMode")]
        public int pdiconPackHeaterMode { get; set; }

        [JsonProperty("ems.maxCloseOilEbSoc")]
        public int emsmaxCloseOilEbSoc { get; set; }

        [JsonProperty("pd.carWatts")]
        public int pdcarWatts { get; set; }

        [JsonProperty("pd.iconAcFreqState")]
        public int pdiconAcFreqState { get; set; }

        [JsonProperty("bmsSlave2.remainTime")]
        public int bmsSlave2remainTime { get; set; }

        [JsonProperty("bmsSlave2.cellVol")]
        public List<int> bmsSlave2cellVol { get; set; }

        [JsonProperty("pd.iconWirelessChgState")]
        public int pdiconWirelessChgState { get; set; }

        [JsonProperty("pd.iconSolarPanelMode")]
        public int pdiconSolarPanelMode { get; set; }

        [JsonProperty("inv.sysVer")]
        public int invsysVer { get; set; }
    }

