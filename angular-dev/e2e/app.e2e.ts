import { AngularDevPage } from './app.po';

describe('angular-dev App', function() {
  let page: AngularDevPage;

  beforeEach(() => {
    page = new AngularDevPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('angular-dev works!');
  });
});
