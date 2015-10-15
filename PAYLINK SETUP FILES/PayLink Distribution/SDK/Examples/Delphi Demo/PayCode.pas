unit PayCode;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, Aesimhei, Main, Utility ;

type
  TPayForm = class(TForm)
    AmountPaid: TPanel;
    ExitButton: TButton;
    Timer1: TTimer;
    Status: TPanel;
    ALabel: TLabel;
    TotalPaid: TPanel;
    procedure Timer1Timer(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure ExitButtonClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  PayForm: TPayForm;

implementation

{$R *.DFM}






procedure TPayForm.Timer1Timer(Sender: TObject);
begin
   TotalPaid.Caption := Format('%n', [(CurrentPaid - PaidAtStart) / 100.0 ]) ;
   if LastPayStatus < 0 then
   begin
      Status.Caption := DecodePayStatus(LastPayStatus) ;
      ExitButton.Enabled := True ;
   end
   else if LastPayStatus > 0 then
   begin
      Status.Caption := ' Finished' ;
   end
   else
      Status.Caption := ' Currently Paying' ;

   Status.Alignment := taLeftJustify ;
end;



procedure TPayForm.FormShow(Sender: TObject);
begin
   Timer1.Enabled := True ;
end;

procedure TPayForm.ExitButtonClick(Sender: TObject);
begin
    Timer1.Enabled := False ;
    if MainForm.DoingPrecise then
    begin
       MainForm.DoingPrecise          := false ;
       MainForm.PayButton.Caption     := 'Pay Value' ;
       MainForm.CoinPay.ReadOnly      := false ;
    end ;
end ;

end.
