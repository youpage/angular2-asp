import { Component, OnInit } from '@angular/core';
import { Router, RouteSegment, RouteTree, OnActivate } from '@angular/router';

import { DataService } from '../shared/services/data.service';
import { ICustomer } from '../shared/interfaces';

@Component({
  moduleId: module.id,
  selector: 'customer-edit',
  templateUrl: 'customerEdit.component.html'
})
export class CustomerEditComponent implements OnActivate
{

  customer: ICustomer =
  {
    customerID: '',
    companyName: '',
    contactName: '',
    address: '',
    city: '',
    postalCode: '',
    country: '',
    phone: ''
  };
    
  constructor(private router: Router, private dataService: DataService) { }

  routerOnActivate(current: RouteSegment, prev?: RouteSegment,
      currTree?: RouteTree, prevTree?: RouteTree) {
      const id = currTree.parent(current).getParam('id');
      this.dataService.getCustomer(id).subscribe((customer: ICustomer) => {
        //Quick and dirty clone used in case user cancels the form
        const cust = JSON.stringify(customer);
        this.customer = JSON.parse(cust);
      });      
  }
  
  onSubmit() {
      this.dataService.updateCustomer(this.customer)
        .subscribe((status: boolean) => {
          this.router.navigate(['/']);
      });
  }
  
  onCancel(event: Event) {
    event.preventDefault();
    this.router.navigate(['/']);
  }
}