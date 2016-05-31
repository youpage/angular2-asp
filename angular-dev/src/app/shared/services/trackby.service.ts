import { Injectable } from '@angular/core';

//import interfaces
import { ICustomer, IOrder } from '../interfaces';

@Injectable()
export class TrackByService {
    customer(index: number, customer: ICustomer) {
        return customer.customerID;
    }
}