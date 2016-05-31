import { Pipe, PipeTransform } from '@angular/core';

//Make first char Uppercase 
@Pipe({ name: 'capitalize' })
export class CapitalizePipe implements PipeTransform {

    transform(value: any) {
        if (value) {
            return value.charAt(0).toUpperCase() + value.slice(1);
        }
        return value;
    }

}