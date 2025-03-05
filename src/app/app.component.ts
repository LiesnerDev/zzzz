import { Component } from '@angular/core';
import { NotificationService } from './notification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private notificationService: NotificationService) { }

  openNotification(): void {
    // Substituindo 'aaa' por uma mensagem relevante
    this.notificationService.showNotification('Mensagem relevante: Operação realizada com sucesso!');
  }
}
