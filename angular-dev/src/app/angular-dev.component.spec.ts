import {
  beforeEachProviders,
  describe,
  expect,
  it,
  inject
} from '@angular/core/testing';
import { AngularDevAppComponent } from '../app/angular-dev.component';

beforeEachProviders(() => [AngularDevAppComponent]);

describe('App: AngularDev', () => {
  it('should create the app',
      inject([AngularDevAppComponent], (app: AngularDevAppComponent) => {
    expect(app).toBeTruthy();
  }));

  it('should have as title \'angular-dev works!\'',
      inject([AngularDevAppComponent], (app: AngularDevAppComponent) => {
    expect(app.title).toEqual('angular-dev works!');
  }));
});
