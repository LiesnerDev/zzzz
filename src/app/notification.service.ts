import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable()
export class NotificationService {
  private notificationSubject = new Subject<string>();
  notification$ = this.notificationSubject.asObservable();

  constructor() {}

  showNotification(message: string): void {
    this.notificationSubject.next(message);
  }
}
