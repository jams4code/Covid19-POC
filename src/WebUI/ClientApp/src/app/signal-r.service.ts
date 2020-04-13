import { Injectable } from '@angular/core';
import * as SignalR from '@microsoft/signalr';
@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: SignalR.HubConnection;
  user : string = '';
  message: string = '';
  messages: string[] = [];
  constructor() { 

  }
  public sendMessage(): void {
    const data = `Sent: ${this.message}`;
 
        if (this.hubConnection) {
            this.hubConnection.invoke('Send', data);
        }
        this.messages.push(data);
    }
 
    ngOnInit() {
        this.hubConnection = new SignalR.HubConnectionBuilder()
            .withUrl('https://localhost:5001/covidhub')
            .configureLogging(SignalR.LogLevel.Information)
            .build();
 
        this.hubConnection.start().catch(err => console.error(err.toString()));
 
        this.hubConnection.on('Send', (data: any) => {
            const received = `Received: ${data}`;
            this.messages.push(received);
        });
    }
}