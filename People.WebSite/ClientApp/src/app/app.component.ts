import { Component } from '@angular/core';
import * as signalR from "@microsoft/signalr";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  // connection = new signalR.HubConnectionBuilder()
  //   .withUrl("https://localhost:5001/HappyBirthday?userId=1234")
  //   .build();

  // SendMessage() {
  //   this.connection.invoke("HappyBirthday", "1234", "در خواست دارم");
  //   console.log('SendMessage', 'called');
  // }

  // ngOnInit(): void {
  //   this.connection.start()
  //     .then(() => {
  //       console.log('MessageHub Connected');
  //     });

  //   this.connection.on('GetHappyBirthdayMessage', data => {
  //     console.log('GetHappyBirthdayMessage',data);
  //   });

  //   this.connection.on("ShowMessage", data => {
  //     console.log('ShowMessage', data);
  //   });

  //   this.connection.on("getNewMessage", data => {
  //     console.log("response data", data);
  //   });

  //}

}

