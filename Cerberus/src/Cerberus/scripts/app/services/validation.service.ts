import { Injectable }               from '@angular/core';
import { AbstractCtrlComponent }    from '../abstractions/abstract.ctrl.component';

@Injectable()
export class ValidationService {

    private controls: AbstractCtrlComponent[];

    public RegisterCtrl(Ctrl: AbstractCtrlComponent): void {
        this.controls.push(Ctrl);
    }

    public IsValid(): boolean {
        let result = true;
        for (let c in this.controls) {
            if (!this.controls[c].IsValid) {
                result = false;
                break;
            }
        }
        return result;
    }

    public ClearControls(): void {
        this.controls = [];
    }
}