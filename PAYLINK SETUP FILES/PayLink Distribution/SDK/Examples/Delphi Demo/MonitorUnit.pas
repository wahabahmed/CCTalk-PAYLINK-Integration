unit MonitorUnit;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, AesImhei;

type
  TMonitorForm = class(TForm)
    MonitorTimer: TTimer;
    Message: TLabel;
    procedure MonitorTimerTimer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  MonitorForm: TMonitorForm;
  Sequence: LongInt ;
implementation

{$R *.DFM}

procedure TMonitorForm.MonitorTimerTimer(Sender: TObject);
var
    Echoed   : LongInt ;
    ErrorMsg : PChar ;
    
begin
    Echoed := CheckOperation(Sequence + 10, 1000) ;
    If (Echoed = Sequence) or (Echoed = -1) Then
    begin
      ErrorMsg := IMHEIConsistencyError(STANDARD_COIN_TIME, STANDARD_NOTE_TIME) ;
      If ErrorMsg = nil Then
      begin
         visible := false ;
      end
      else
      begin
        Message.Caption := ErrorMsg ;
        MonitorForm.Width := Message.Width + Message.Left * 2 + 4 ;
        visible := true ;
      end
    end
    else if Sequence <> 0 Then
    begin
        Message.Caption := 'Paylink has stopped responding' ;
        MonitorForm.Width := Message.Width + Message.Left * 2 + 4 ;
        visible := true ;
    end ;
    Sequence := Sequence + 10 ;
end;

end.
