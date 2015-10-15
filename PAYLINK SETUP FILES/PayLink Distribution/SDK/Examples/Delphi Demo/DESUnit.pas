unit DESUnit;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, AesImhei;

type
  TDESForm = class(TForm)
    TheLabel: TLabel;
    ExitButton: TButton;
    DESTimer: TTimer;
    Status: TPanel;
    SetKeyButton: TButton;
    LockButton: TButton;
    UnlockButton: TButton;
    DESKey: TEdit;
    NewKey: TEdit;
    procedure ExitButtonClick(Sender: TObject);
    procedure DESTimerTimer(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure FormHide(Sender: TObject);
    procedure SetKeyButtonClick(Sender: TObject);
    procedure LockButtonClick(Sender: TObject);
    procedure UnlockButtonClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DESForm: TDESForm;

implementation

{$R *.DFM}



procedure TDESForm.ExitButtonClick(Sender: TObject);
begin
    DesForm.Hide ;
end;




procedure TDESForm.DESTimerTimer(Sender: TObject);
var
    TheStatus     : LongInt ;
begin
    TheStatus  := DESStatus ;
    case TheStatus of
    DES_UNLOCKED :     Status.Caption   :=  'Unlocked' ;
    DES_MATCH    :     Status.Caption   :=  'Matched' ;
    DES_NOT      :     Status.Caption   :=  'Not DES!' ;
    DES_WRONG    :     Status.Caption   :=  'Wrong Key' ;
    DES_CHECKING :     Status.Caption   :=  'Checking' ;
    DES_APPLYING :     Status.Caption   :=  'Applying' ;
    else               Status.Caption   :=  'Unknown' ;
    end ;
end;

procedure TDESForm.FormActivate(Sender: TObject);
begin
    DESTimer.Enabled := true ;
end;

procedure TDESForm.FormHide(Sender: TObject);
begin
    DESTimer.Enabled := false ;
end;

procedure TDESForm.SetKeyButtonClick(Sender: TObject);
var
    Key: Array [0..7] of AnsiChar ;
    i : Integer ;
begin
    for i := 0 to 7 do
    begin
        Key[i] := Chr((Ord(DESKey.Text[i * 2 + 1]) * 16) + (Ord(DesKey.Text[i * 2 + 2]) and 15)) ;
    end ;
    DESSetKey(Key) ;
end;

procedure TDESForm.LockButtonClick(Sender: TObject);
var
    Key: Array [0..7] of AnsiChar ;
    i : Integer ;
begin
    for i := 0 to 7 do
    begin
        Key[i] := Chr((Ord(DESKey.Text[i * 2 + 1]) * 16) + (Ord(DesKey.Text[i * 2 + 2]) and 15)) ;
    end ;
    DESLockSet(Key) ;
end;

procedure TDESForm.UnlockButtonClick(Sender: TObject);
begin
    DESLockClear() ;
end;

end.
