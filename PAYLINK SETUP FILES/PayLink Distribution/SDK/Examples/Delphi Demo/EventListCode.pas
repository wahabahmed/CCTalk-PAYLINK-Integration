unit EventListCode;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, ComCtrls;

type
  TEventList = class(TForm)
    Events: TRichEdit;
    procedure FormDeactivate(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure EventsChange(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  EventList: TEventList;

implementation

{$R *.DFM}

uses Main ;

procedure TEventList.FormDeactivate(Sender: TObject);
begin
    Hide ;
    MainForm.EventCaption.Caption := 'Latest Event' ;

end;

procedure TEventList.FormShow(Sender: TObject);
begin
    Events.SelectAll() ;
    Events.Paragraph.TabCount := 1 ;
    Events.Paragraph.Tab[0] := EventTab ;
    Events.SelLength := 0 ;
end;


procedure TEventList.EventsChange(Sender: TObject);
begin
    Events.SelectAll() ;
    Events.Paragraph.TabCount := 1 ;
    Events.Paragraph.Tab[0] := EventTab ;
    Events.SelLength := 0 ;
end;

end.
