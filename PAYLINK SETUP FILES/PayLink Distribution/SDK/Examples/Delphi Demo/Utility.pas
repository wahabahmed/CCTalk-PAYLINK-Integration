unit Utility;

interface
uses Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
    StdCtrls, ExtCtrls, AesImhei ;

procedure CreatePanel(var Dest, Src : TPanel ; Left : Integer ; Top : Integer) ;
procedure CreateEdit(var Dest, Src : TEdit ; Left : Integer ; Top : Integer) ;
function  DecodePayStatus(PayStatus : Integer) : string ;

implementation


function  DecodePayStatus(PayStatus : Integer) : string ;
begin
      Case PayStatus of
       PAY_FINISHED      :  DecodePayStatus := 'Idle OK' ;
       PAY_ONGOING       :  DecodePayStatus := 'Paying' ;
       PAY_EMPTY         :  DecodePayStatus := 'Empty' ;
       PAY_JAMMED        :  DecodePayStatus := 'Jammed' ;
       PAY_US            :  DecodePayStatus := 'U/S' ;
       PAY_FRAUD         :  DecodePayStatus := 'Fraud Attempt' ;
       PAY_FAILED_BLOCKED:  DecodePayStatus := 'Blocked' ;
       PAY_NO_HOPPER     :  DecodePayStatus := 'No Dispenser' ;
       PAY_INHIBITED     :  DecodePayStatus := 'Inhibited' ;  
       PAY_SECURITY_FAIL :  DecodePayStatus := 'Security Fail' ;
       PAY_HOPPER_RESET  :  DecodePayStatus := 'Dispenser Reset' ;
       PAY_NOT_EXACT     :  DecodePayStatus := 'No Exact Coin' ;
       PAY_GHOST         :  DecodePayStatus := 'Ghost' ;
       PAY_NO_KEY        :  DecodePayStatus := 'Waiting for Key' ;
       
       DISPENSER_REASSIGN_VALUE   :  DecodePayStatus := 'Reassigning' ;
       DISPENSER_VALUE_REASSIGNED :  DecodePayStatus := 'Reassigned' ;
       
       DISPENSER_CASHBOX_DUMP     :  DecodePayStatus := 'Dumping' ;
       DISPENSER_PARTIAL_DUMP     :  DecodePayStatus := 'Partial Dumping' ;
       DISPENSER_DUMP_FINISHED    :  DecodePayStatus := 'Dump Finished' ;


       
       else DecodePayStatus := format('Error %d', [PayStatus]) ;
       end ;
end ;

procedure CreatePanel(var Dest, Src : TPanel ; Left : Integer ; Top : Integer) ;
begin
    Dest            := TPanel.Create(Src.Owner) ;
    Dest.Caption    := 'xx' ;
    Dest.Tag        := Left + Top ;
    Dest.Parent     := Src.Parent ;
    Dest.Height     := Src.Height ;
    Dest.Top        := Src.Top + (Src.Height + 4) * Top ;
    Dest.Width      := Src.Width ;
    Dest.Font       := Src.Font ;
    Dest.BevelInner := Src.BevelInner ;
    Dest.BevelOuter := Src.BevelOuter ;
    Dest.Color      := Src.Color ;
    Dest.Alignment  := Src.Alignment ;
    Dest.Left       := Src.Left + (Src.Width + 4) * Left ;
    Dest.Visible    := True ;
end ;




procedure CreateEdit(var Dest, Src : TEdit ; Left : Integer ; Top : Integer) ;
begin
    Dest            := TEdit.Create(Src.Owner) ;
    Dest.Text       := 'xx' ;
    Dest.Tag        := Left + Top ;
    Dest.AutoSize   := Src.AutoSize ;
    Dest.Parent     := Src.Parent ;
    Dest.Height     := Src.Height ;
    Dest.Top        := Src.Top + (Src.Height + 4) * Top ;
    Dest.Width      := Src.Width ;
    Dest.Font       := Src.Font ;
    Dest.BorderStyle := Src.BorderStyle ;
    Dest.Color      := Src.Color ;
    Dest.Left       := Src.Left + (Src.Width + 4) * Left ;
    Dest.Visible    := True ;
    Dest.OnChange   := Src.OnChange ;
end ;

end.
 
