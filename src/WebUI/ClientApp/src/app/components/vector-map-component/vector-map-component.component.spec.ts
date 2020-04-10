import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VectorMapComponentComponent } from './vector-map-component.component';

describe('VectorMapComponentComponent', () => {
  let component: VectorMapComponentComponent;
  let fixture: ComponentFixture<VectorMapComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VectorMapComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VectorMapComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
