Notes for this Assignment:

in FSM State key:

WaitingForPayment = WFP
WaitingForSelection = WFS
Vending = cending

FSM= M = (S, A, t)

S = WFP, WFS, vending     ,    initialstate = WFP
A = pay, cancel, select(buy)
output = product, change, nothing

t = 		pay,		cancel,	select

	WFP, WFP|nothing  WFP|change	WFS|nothing
	
	WFS, WFS|nothing	WFP|change  vend|product
 
	Vend,vend|change  vend|change WFP|nothing