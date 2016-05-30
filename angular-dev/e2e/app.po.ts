export class AngularDevPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('angular-dev-app h1')).getText();
  }
}
