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

  ngOnInit() {
    this.loadMessages();
    this.startConnection();
  }

  get sortedMessages () {
    return this.messages.sort((x, y) => x.createdAt < y.createdAt ? -1 : 1);
  }

  async startConnection () {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/signalr/messages")
      .build();

    await this.connection.start();
    this.connection.on("SendMessage", x => this.messages.push(x))
  }

  loadMessages () {
    this.client.list().subscribe(x => this.messages = x)
  }
}
