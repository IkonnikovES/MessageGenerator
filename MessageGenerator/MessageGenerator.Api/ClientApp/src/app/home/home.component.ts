import { Component } from '@angular/core';
import { IChatMessageModel, MessageClient } from 'src/api/api'
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private client: MessageClient;
  private connection: signalR.HubConnection;

  public messages: IChatMessageModel[] = [];

  constructor(client: MessageClient) {
    this.client = client;
  }

  async ngOnInit() {
    await this.startConnection();
    this.loadMessages();
  }

  get sortedMessages () {
    return this.messages.sort((x, y) => x.createdAt < y.createdAt ? -1 : 1);
  }

  async startConnection () {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/signalr/messages")
      .build();

    this.connection.on("SendMessage", x => this.messages.push(x))
    return this.connection.start();
  }

  loadMessages () {
    this.client.list().subscribe(x => this.messages = x);
  }
}
