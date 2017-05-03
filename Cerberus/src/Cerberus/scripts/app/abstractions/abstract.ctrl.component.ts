import { ValidationService }            from '../services/validation.service';

export class AbstractCtrlComponent {
    constructor(protected validation_service: ValidationService) {
        this.register_ctrl();
    }

    private register_ctrl(): void {
        this.validation_service
    }

    public IsValid: boolean = true;
}