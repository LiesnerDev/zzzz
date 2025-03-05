import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NotificationComponent } from './notification.component';
import { NotificationService } from './notification.service';
import { of } from 'rxjs';
import { NotificationResponse } from './notification-response.model';

// For testing template interactions
import { By } from '@angular/platform-browser';
import { Component } from '@angular/core';

describe('NotificationComponent', () => {
  let component: NotificationComponent;
  let fixture: ComponentFixture<NotificationComponent>;
  let notificationServiceSpy: jasmine.SpyObj<NotificationService>;

  beforeEach(async () => {
    const spy = jasmine.createSpyObj('NotificationService', ['getAlert']);

    await TestBed.configureTestingModule({
      declarations: [NotificationComponent],
      providers: [
        { provide: NotificationService, useValue: spy }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(NotificationComponent);
    component = fixture.componentInstance;
    notificationServiceSpy = TestBed.inject(NotificationService) as jasmine.SpyObj<NotificationService>;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should display modal alert when response displayMode is modal', () => {
    const mockResponse: NotificationResponse = { message: 'aaaa', displayMode: 'modal' };
    notificationServiceSpy.getAlert.and.returnValue(of(mockResponse));

    component.fetchAlert(false);
    fixture.detectChanges();

    expect(component.alertMessage).toBe('aaaa');
    expect(component.showModal).toBeTrue();
    expect(component.showNonIntrusive).toBeFalse();
  });

  it('should display non-intrusive alert when response displayMode is not modal', () => {
    const mockResponse: NotificationResponse = { message: 'aaaa', displayMode: 'nonIntrusive' };
    notificationServiceSpy.getAlert.and.returnValue(of(mockResponse));

    component.fetchAlert(true);
    fixture.detectChanges();

    expect(component.alertMessage).toBe('aaaa');
    expect(component.showModal).toBeFalse();
    expect(component.showNonIntrusive).toBeTrue();
  });

  it('should close modal when closeModal is called', () => {
    component.showModal = true;
    component.closeModal();
    expect(component.showModal).toBeFalse();
  });

  it('should close non-intrusive alert when closeNonIntrusive is called', () => {
    component.showNonIntrusive = true;
    component.closeNonIntrusive();
    expect(component.showNonIntrusive).toBeFalse();
  });

  it('should validate that the alert message is exactly "aaaa"', () => {
    const mockResponse: NotificationResponse = { message: 'aaaa', displayMode: 'modal' };
    notificationServiceSpy.getAlert.and.returnValue(of(mockResponse));

    component.fetchAlert(false);
    fixture.detectChanges();

    expect(component.alertMessage).toBe('aaaa');
  });
});
