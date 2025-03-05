import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {

  messages: string[] = [];
  private subscription: Subscription | undefined;

  constructor(private notificationService: NotificationService) {}

  ngOnInit(): void {
    this.subscription = this.notificationService.notification$.subscribe((message: string) => {
      // Substituir "aaa" caso apareça na mensagem
      const finalMessage = message.replace(/aaa/g, 'Mensagem Relevante');
      this.messages.push(finalMessage);
      // Exemplo: remover notificação após 5 segundos
      setTimeout(() => {
        this.removeMessage(finalMessage);
      }, 5000);
    });
  }

  removeMessage(message: string): void {
    const index = this.messages.indexOf(message);
    if (index >= 0) {
      this.messages.splice(index, 1);
    }
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
