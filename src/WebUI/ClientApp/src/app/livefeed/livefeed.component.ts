import { Component, OnInit } from '@angular/core';
import * as SignalR from '@microsoft/signalr';
import { ChatItemDTO, LiveClient, ChatHubCommand } from '../covid19-api';
@Component({
  selector: 'app-livefeed',
  templateUrl: './livefeed.component.html',
  styleUrls: ['./livefeed.component.css']
})
export class LivefeedComponent implements OnInit {
  // constructor() { }

  // ngOnInit(): void {
  // }

  //Test HUB
  private hubConnection: SignalR.HubConnection;
  user : string = '';
  message: string = '';
  chat: ChatItemDTO[] = [];
  constructor(private liveClient: LiveClient) { 

  }
  public sendMessage(): void { 
        if (this.hubConnection) {
            this.hubConnection.invoke('SendMessage', this.user, this.message);
            this.liveClient.sendMessage(<ChatHubCommand>{user: this.user, message: this.message}).subscribe(
              () => {
                  console.log("message saved")
              },
              error => console.error(error)
          );
        }
    }
 
    ngOnInit() {
        this.hubConnection = new SignalR.HubConnectionBuilder()
            .withUrl('https://localhost:5001/hub')
            .configureLogging(SignalR.LogLevel.Information)
            .build();
 
        this.hubConnection.start().catch(err => console.error(err.toString()));
 
        this.hubConnection.on('ReceiveMessage', (data: any,data2:any) => {
            this.chat.push(<ChatItemDTO>{user: data, message: data2});
        });
    }
}


