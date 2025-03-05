import { NotificationResponse } from './notification-response.model';

describe('NotificationResponse Model', () => {
  it('should have the expected properties', () => {
    const response: NotificationResponse = {
      message: 'aaaa',
      displayMode: 'modal'
    };
    expect(response.message).toBe('aaaa');
    expect(response.displayMode).toBe('modal');
  });
});
