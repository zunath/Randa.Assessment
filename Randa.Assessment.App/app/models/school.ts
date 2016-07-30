import { ODataModel } from './odataModel'

export class School extends ODataModel {
    constructor(public id: number, public name: string) {
        super();
    }
}