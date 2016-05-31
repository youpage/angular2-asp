export interface ICustomer {
    customerID: string;
    companyName: string;
    contactName: string;
    address: string;
    city: string;
    postalCode: string;
    country: string;
    phone: string;
}

export interface IOrder {
    orderID: number;
    customerID: string;    
    orderDate: string;
}

export interface IOrderDetails{
    items: IOrderDetails[];
}

export interface IOrderItem {
    orderID: number;
    productID: number;
    product: IProduct;
    quantity: number;
    discount: number;
}

export interface IProduct {
    productID: number;
    productName: string;
    unitPrice?: number;    
}
