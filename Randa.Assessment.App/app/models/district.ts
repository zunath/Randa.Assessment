import { ODataModel } from './odataModel'

export class District extends ODataModel {
    constructor(public id: number, public name: string) {
        super();
    }
}