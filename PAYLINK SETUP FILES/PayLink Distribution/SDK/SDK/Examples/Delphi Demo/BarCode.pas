unit BarCode;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, AesImhei, ExtCtrls ;

type
  TBarCodeForm = class(TForm)
    BarCodeOffButton: TButton;
    TheLabel: TLabel;
    TicketInEscrow: TPanel;
    TicketAcceptButton: TButton;
    TicketReturnButton: TButton;
    TicketStacked: TPanel;
    TicketCount: TPanel;
    PrinterTimer: TTimer;
    PrintButton: TButton;
    PrintBarcode: TEdit;
    StatusReport: TPanel;
    AmountWords: TEdit;
    AmountNumber: TEdit;
    PrintDate: TEdit;
    PrintTime: TEdit;
    McId: TEdit;
    procedure BarCodeOffButtonClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure PrinterTimerTimer(Sender: TObject);
    procedure TicketAcceptButtonClick(Sender: TObject);
    procedure TicketReturnButtonClick(Sender: TObject);
    procedure PrintButtonClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  BarCodeForm: TBarCodeForm;

implementation

{$R *.DFM}
var
OldBarcodeCount : LongInt ;

procedure TBarCodeForm.BarCodeOffButtonClick(Sender: TObject);
begin
    PrinterTimer.Enabled := false;
    BarcodeDisable ;
    Visible := False ;
end;

procedure TBarCodeForm.FormShow(Sender: TObject);
var
   BarcodeTicket : Array [0..19] of Char ;
begin
    TicketInEscrow.Caption := '' ;
    TicketStacked.Caption := '' ;
    TicketCount.Caption := '' ;
    PrinterTimer.Enabled := true ;
    OldBarcodeCount := BarcodeStacked(BarcodeTicket) ;
    BarcodeEnable ;
end;







procedure TBarCodeForm.PrinterTimerTimer(Sender: TObject);
var
   BarcodeTicket : Array [0..41] of Char ;
   BarcodesRead  : LongInt ;
   BarcodeStatus : LongInt ;
begin
   if BarcodeInEscrowExt(BarcodeTicket, 41) <> 0 then
   begin
       TicketInEscrow.Caption := BarcodeTicket ;
       TicketInEscrow.Color := clWhite ;
   end
   else
   begin
       TicketInEscrow.Caption := '' ;
       TicketInEscrow.Color := clBtnFace ;
   end ;

   BarcodesRead := BarcodeStackedExt(BarcodeTicket, 41) ;
   if BarcodesRead <> OldBarcodeCount then
   begin
       TicketStacked.Caption := BarcodeTicket ;
       TicketCount.Caption := InttoStr(BarcodesRead) ;
       OldBarcodeCount := BarcodesRead ;
   end ;

   PrinterTimer.Interval := 100 ;

   BarcodeStatus := BarcodePrintStatus ;
   if (BarcodeStatus AND PRINTER_IDLE) <> 0 then
   begin
       StatusReport.Caption := 'Idle (OK)' ;
       PrintButton.Enabled := true ;
   end else
   if BarcodeStatus = PRINTER_NONE then
   begin
       StatusReport.Caption := 'No printer' ;
       PrintButton.Enabled := false ;
   end else
   if (BarcodeStatus AND PRINTER_BUSY) <> 0 then
   begin
       StatusReport.Caption := 'Busy printing' ;
       PrintButton.Enabled := false ;
       PrinterTimer.Interval := 10 ;
   end else
   begin
       StatusReport.Caption := IntToHex(BarcodeStatus, 8) ;
       PrintButton.Enabled := false ;
   end ;
end;



procedure TBarCodeForm.TicketAcceptButtonClick(Sender: TObject);
begin
    BarcodeAccept ;
end;




procedure TBarCodeForm.TicketReturnButtonClick(Sender: TObject);
begin
    BarcodeReturn ;
end;







procedure TBarCodeForm.PrintButtonClick(Sender: TObject);
var
    TicketDetails: TTicketDescription ;
    BarcodeDataString     : string ;
    AmountInWordsString   : string ;  
    AmountAsNumberString  : string ; 
    MachineIdentityString : string ;
    DatePrintedString     : string ;    
    TimePrintedString     : string ;    
    
    
begin
    TicketDetails.TicketType      := 0 ;

    BarcodeDataString     := PrintBarcode.Text ;
    AmountInWordsString   := AmountWords.Text ;
    AmountAsNumberString  := AmountNumber.Text ;
    MachineIdentityString := McId.Text ;
    DatePrintedString     := PrintDate.Text ;
    TimePrintedString     := PrintTime.Text ;

    TicketDetails.BarcodeData     := PChar(BarcodeDataString) ;
    TicketDetails.AmountInWords   := PChar(AmountInWordsString) ;
    TicketDetails.AmountAsNumber  := PChar(AmountAsNumberString) ;
    TicketDetails.MachineIdentity := PChar(MachineIdentityString) ;
    TicketDetails.DatePrinted     := PChar(DatePrintedString) ;
    TicketDetails.TimePrinted     := PChar(TimePrintedString) ;
    BarcodePrint(TicketDetails) ;
    PrinterTimer.Interval := 10 ;
end;

end.
