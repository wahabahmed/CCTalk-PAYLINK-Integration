unit MoreDetailUnit;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, AesImhei;

type
  TMoreDetail = class(TForm)
    DumpGroup: TGroupBox;
    DumpAll: TButton;
    DumpOnly: TButton;
    ExitButton: TButton;
    CoinCount: TEdit;
    SetButton: TButton;
    ExitButton2: TButton;
    PayCount: TEdit;
    procedure DumpAllClick(Sender: TObject);
    procedure CoinCountChange(Sender: TObject);
    procedure DumpOnlyClick(Sender: TObject);
    procedure CoinCountKeyPress(Sender: TObject; var Key: Char);
    procedure FormActivate(Sender: TObject);
    procedure SetButtonClick(Sender: TObject);
    procedure PayCountChange(Sender: TObject);
    procedure PayCountKeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
    DispenserNumber: integer ;
  end;

var
  MoreDetail: TMoreDetail;
  
  HopperSetting : array [0..63] of LongInt ;
  
implementation

uses Main;

{$R *.DFM}





procedure TMoreDetail.FormActivate(Sender: TObject);
var
    Dispenser: TDispenserBlock ;
begin
    ReadDispenserDetails(DispenserNumber, Dispenser) ;
    if (Dispenser.UnitType and DP_GENERIC_MASK) = DP_NOTE_PAYOUT_DEVICE  then
    begin
       DumpGroup.Visible := true ;
       Width := DumpGroup.Left + DumpGroup.Width + 20 ;
    end
    else
    begin
       DumpGroup.Visible := false ;
       Width := DumpGroup.Left + 5 ;
    end ;
end;








procedure TMoreDetail.SetButtonClick(Sender: TObject);
var
    Dispenser : TDispenserBlock ;
    Count     : Integer ;
    Code      : Integer ;
begin
    ReadDispenserDetails(DispenserNumber, Dispenser) ;
    
    Val(PayCount.Text, Count, Code) ;
    if SetDispenseQuantity(DispenserNumber, Count, Dispenser.Value) = 0 then
    begin
        ShowMessage('Failed to set ' + IntToStr(Count) + ' in dispenser') ;
    end
    else
    begin
        if MainForm.DoingPrecise then
        begin
           MainForm.CoinPay.Tag := MainForm.CoinPay.Tag + Count * Dispenser.Value - HopperSetting[DispenserNumber] ;
           HopperSetting[DispenserNumber] := Count * Dispenser.Value ;
        end
        else
        begin
           FillChar(HopperSetting, SizeOf(HopperSetting), 0) ; 
           HopperSetting[DispenserNumber] := Count * Dispenser.Value ;
           MainForm.CoinPay.Tag           := Count * Dispenser.Value ;
           MainForm.CoinPay.ReadOnly      := true ;
           MainForm.DoingPrecise          := true ;
           MainForm.PayButton.Caption     := 'Precise Pay' ;
        end ;
        MainForm.CoinPay.Text := Format('%n', [MainForm.CoinPay.Tag * 0.01]) ;
    end ;
    
end;



procedure TMoreDetail.PayCountChange(Sender: TObject);
var
  I    : Integer ;
  Code : Integer ;
begin
  Val(PayCount.Text, I, Code);
  SetButton.Enabled := I <> 0 ;
end;



procedure TMoreDetail.PayCountKeyPress(Sender: TObject; var Key: Char);
begin
    if Ord(Key) = 13 then
        SetButtonClick(Sender) ; 
end;



{***************************************************
These are concerned with Dispemser dump processing
****************************************************}




procedure TMoreDetail.DumpAllClick(Sender: TObject);
var
    Dispenser: TDispenserBlock ;
begin
    ReadDispenserDetails(DispenserNumber, Dispenser) ;
    Dispenser.Status := DISPENSER_CASHBOX_DUMP ;
    WriteDispenserDetails(DispenserNumber, Dispenser) ;
end;



procedure TMoreDetail.CoinCountChange(Sender: TObject);
var
  I    : Integer ;
  Code : Integer ;
 begin
  Val(CoinCount.Text, I, Code);
  DumpOnly.Enabled := I <> 0 ;
end;



procedure TMoreDetail.DumpOnlyClick(Sender: TObject);
var
    Dispenser : TDispenserBlock ;
    I         : Integer ;
    Code      : Integer ;
begin
    ReadDispenserDetails(DispenserNumber, Dispenser) ;
    Dispenser.Status := DISPENSER_PARTIAL_DUMP ;
    Val(CoinCount.Text, I, Code);
    Dispenser.NotesToDump := I ;
    WriteDispenserDetails(DispenserNumber, Dispenser) ;
end;



procedure TMoreDetail.CoinCountKeyPress(Sender: TObject; var Key: Char);
begin
    if Ord(Key) = 13 then
        DumpOnlyClick(Sender) ; 
end;



end.
