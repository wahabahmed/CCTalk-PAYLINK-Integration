program Demo;

uses
  Forms,
  Main in 'Main.pas' {MainForm},
  PayCode in 'PayCode.pas' {PayForm},
  aesimhei in '..\..\aesimhei.pas',
  Acceptors in 'Acceptors.pas' {AcceptorsForm},
  SwitchUnit in 'SwitchUnit.pas' {SwitchForm},
  MeterUnit in 'MeterUnit.pas' {MeterForm},
  Dispensers in 'Dispensers.pas' {DispensersForm},
  Utility in 'Utility.pas',
  EventListCode in 'EventListCode.pas' {EventList},
  ImheiEvent in '..\..\ImheiEvent.pas',
  BarCode in 'BarCode.pas' {BarCodeForm},
  MonitorUnit in 'MonitorUnit.pas' {MonitorForm},
  DESUnit in 'DESUnit.pas' {DESForm},
  MoreDetailUnit in 'MoreDetailUnit.pas' {MoreDetail};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TPayForm, PayForm);
  Application.CreateForm(TAcceptorsForm, AcceptorsForm);
  Application.CreateForm(TSwitchForm, SwitchForm);
  Application.CreateForm(TMeterForm, MeterForm);
  Application.CreateForm(TDispensersForm, DispensersForm);
  Application.CreateForm(TEventList, EventList);
  Application.CreateForm(TBarCodeForm, BarCodeForm);
  Application.CreateForm(TMonitorForm, MonitorForm);
  Application.CreateForm(TDESForm, DESForm);
  Application.CreateForm(TMoreDetail, MoreDetail);
  Application.Run;
end.
