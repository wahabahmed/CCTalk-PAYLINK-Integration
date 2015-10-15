unit MeterUnit;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ComCtrls, StdCtrls, ExtCtrls, AesImhei;

type
  TMeterForm = class(TForm)
    TheLabel: TLabel;
    MeterInc: TButton;
    IncUpDown: TUpDown;
    ThePanel: TPanel;
    MeterUpDown: TUpDown;
    ExitButton: TButton;
    MeterStatus: TPanel;
    DisplayUpDown: TUpDown;
    CurrentMeter: TEdit;
    ShowCounter: TRadioButton;
    CycleAll: TRadioButton;
    DisplayCode: TEdit;
    MeterTimer: TTimer;
    Text: TEdit;
    CounterRead: TPanel;
    MeterSerial: TPanel;
    procedure MeterIncClick(Sender: TObject);
    procedure ExitButtonClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure CurrentMeterChange(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure MeterUpDownClick(Sender: TObject; Button: TUDBtnType);
    procedure IncUpDownClick(Sender: TObject; Button: TUDBtnType);
    procedure ShowCounterClick(Sender: TObject);
    procedure CycleAllClick(Sender: TObject);
    procedure DisplayUpDownClick(Sender: TObject; Button: TUDBtnType);
    procedure DisplayCodeChange(Sender: TObject);
    procedure MeterTimerTimer(Sender: TObject);
    procedure TextChange(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  MeterForm: TMeterForm;
  
  MeterText : array [1..32] of string ;  

  CodeFactor : LongInt ;

implementation

{$R *.DFM}


procedure SetMeterStatus ;
begin
    MeterForm.MeterSerial.Caption := IntToHex(MeterSerialNo, 8) ;
    case MeterStatus of
      METER_OK:     MeterForm.MeterStatus.Caption := 'OK'  ;
      METER_DIED:   MeterForm.MeterStatus.Caption := 'Dead'  ;
      METER_FAILED: MeterForm.MeterStatus.Caption := 'Failed';
      else
      begin
                    MeterForm.MeterStatus.Caption := 'Not Present' ;
                    MeterForm.MeterSerial.Caption := '' ;
      end
    end ;
    MeterForm.Text.Text := ReadCounterCaption(MeterForm.MeterUpDown.Position) ;
    MeterForm.CounterRead.Caption := IntToStr(CounterRead(MeterForm.MeterUpDown.Position)) ;
 end ;




procedure TMeterForm.FormShow(Sender: TObject);
begin
    SetMeterStatus ;
    MeterTimer.Enabled := True ;
end;




procedure TMeterForm.FormCreate(Sender: TObject);
begin
    CounterCaption(1, 'REFILL' ) ;
    CounterCaption(2, 'CASH IN') ;
    CounterCaption(3, 'CASHOUT') ;
    CounterCaption(4, 'TOCN IN') ;
    CounterCaption(5, 'TOCNOUT') ;
    CounterCaption(6, 'NOTESIN') ;
    CounterCaption(7, 'PRIEOUT') ;
    ShowCounter.Checked := True ;
end;
    




procedure TMeterForm.ExitButtonClick(Sender: TObject);
begin
    Visible := False ;
    MeterTimer.Enabled := False ;
end;




procedure TMeterForm.MeterIncClick(Sender: TObject);
begin
    CounterIncrement(MeterUpDown.Position, IncUpDown.Position) ;
end;

procedure TMeterForm.IncUpDownClick(Sender: TObject; Button: TUDBtnType);
begin
  MeterInc.Caption := 'By ' + InttoStr(IncUpDown.Position) ;
end;



procedure TMeterForm.TextChange(Sender: TObject);
begin
   With Sender as TEdit do
   begin
     CounterCaption(MeterUpDown.Position, PChar(Text)) ;
   end;
end;





procedure TMeterForm.MeterUpDownClick(Sender: TObject; Button: TUDBtnType);
begin
  CurrentMeter.Text := InttoStr(MeterUpDown.Position) ;
  SetMeterStatus ;
end;

procedure TMeterForm.CurrentMeterChange(Sender: TObject);
  var NewValue : Integer ;
begin
  try
    NewValue := 0 ;
    if CurrentMeter.Text <> ''
    then
        NewValue := StrToInt(CurrentMeter.Text) ;
    if (0 < NewValue) and (NewValue < 33) then
    begin
       MeterUpDown.Position := NewValue ;
       MeterInc.Enabled := True ;
    end else begin
       Text.Text := 'Invalid' ;
       MeterInc.Enabled := False ;
    end ;
  except ;
    CurrentMeter.Text := InttoStr(MeterUpDown.Position) ;
  end ;
end;







procedure TMeterForm.DisplayUpDownClick(Sender: TObject; Button: TUDBtnType);
begin
  DisplayCode.Text := InttoStr(DisplayUpDown.Position) ;
end;

procedure TMeterForm.DisplayCodeChange(Sender: TObject);
  var NewValue : Integer ;
begin
  try
    NewValue := 0 ;
    if DisplayCode.Text <> ''
    then
        NewValue := StrToInt(DisplayCode.Text) ;
    if NewValue < 32 then
    begin
       DisplayUpDown.Position := NewValue ;
    end ;
  except ;
    DisplayCode.Text := InttoStr(DisplayUpDown.Position) ;
  end ;
    CounterDisplay(DisplayUpDown.Position * CodeFactor) ;
end;




procedure TMeterForm.ShowCounterClick(Sender: TObject);
begin
    CodeFactor := +1 ;
    CounterDisplay(DisplayUpDown.Position * CodeFactor) ;
end;

procedure TMeterForm.CycleAllClick(Sender: TObject);
begin
    CodeFactor := -1 ;
    CounterDisplay(DisplayUpDown.Position * CodeFactor) ;
end;



procedure TMeterForm.MeterTimerTimer(Sender: TObject);
begin
    SetMeterStatus ;
end;





end.
