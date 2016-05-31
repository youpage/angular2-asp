import {Pipe, PipeTransform} from '@angular/core';

//Remove whitespace from both sides of a string
@Pipe({ name: 'trim' })
export class TrimPipe implements PipeTransform {
    transform(value: any) {
        if (!value) {
            return '';
        }
        return value.trim();
    }
}