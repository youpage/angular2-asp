import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Observer} from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { HttpUtils } from '../utils/httpUtils';

//impport interfaces
import {ICustomer} from '../interfaces';

@Injectable()
export class DataService {
    apiEndpoint: string = 'http://localhost:5000/api/';
    customers: ICustomer[];
    //orders: IOrder[];

    constructor(private http: Http, private httpUtils: HttpUtils) { }

    getCustomers(): Observable<ICustomer[]> {
        if (!this.customers) {
            return this.http.get(this.apiEndpoint + 'customer')
                .map((res: Response) => {
                    this.customers = res.json();
                    //console.log(this.customers);
                    return this.customers;
                })
                .catch(this.handleError);
        }
        else {
            //return cached data
            return this.createObservable(this.customers);
        }
    }

    getCustomer(id: string): Observable<ICustomer> {
        if (this.customers) {
            //filter using cached data
            return this.findCustomerObservable(id);
        } else {
            //Query the existing customers to find the target customer
            return Observable.create((observer: Observer<ICustomer>) => {
                this.getCustomers().subscribe((customers: ICustomer[]) => {
                    this.customers = customers;
                    const cust = this.filterCustomers(id);
                    observer.next(cust);
                    observer.complete();
                })
            })
                .catch(this.handleError);
        }
    }

    //local updateCustomer local object    
    updateCustomerLocal(customer: ICustomer): Observable<boolean> {
        return Observable.create((observer: Observer<boolean>) => {
            this.customers.forEach((cust: ICustomer, index: number) => {
                if (cust.customerID === customer.customerID) {
                    this.customers[index] = customer;
                }
            });
            observer.next(true);
            observer.complete();
        });
    }

    //update to DB
    updateCustomer(customer: ICustomer) {
        return this.http.put(this.apiEndpoint + 'customer',
            JSON.stringify(customer), this.httpUtils.getJsonRequestOptions())
            .map((response: Response) => {
                return response.json();
            });
    }

    private createObservable(data: any): Observable<any> {
        return Observable.create((observer: Observer<any>) => {
            observer.next(data);
            observer.complete();
        });
    }

    private findCustomerObservable(id: string): Observable<ICustomer> {
        return this.createObservable(this.filterCustomers(id));
    }

    private filterCustomers(id: string): ICustomer {
        const custs = this.customers.filter((cust) => cust.customerID === id);
        return (custs.length) ? custs[0] : null;
    }

    private handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}