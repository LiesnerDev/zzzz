import { TestBed } from '@angular/core/testing';
import { NotificationService } from './notification.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { NotificationResponse } from './notification-response.model';

describe('NotificationService', () => {
  let service: NotificationService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [NotificationService]
    });
    service = TestBed.inject(NotificationService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get alert with modal as default (avoidInterrupt false)', () => {
    const mockResponse: NotificationResponse = {
      message: 'aaaa',
      displayMode: 'modal'
    };

    service.getAlert().subscribe(response => {
      expect(response).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(request => 
      request.url === '/api/Notification/alert' && request.params.get('avoidInterrupt') === 'false'
    );
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });

  it('should get alert with non-intrusive mode when avoidInterrupt is true', () => {
    const mockResponse: NotificationResponse = {
      message: 'aaaa',
      displayMode: 'nonIntrusive'
    };

    service.getAlert(true).subscribe(response => {
      expect(response).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(request => 
      request.url === '/api/Notification/alert' && request.params.get('avoidInterrupt') === 'true'
    );
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });
});
