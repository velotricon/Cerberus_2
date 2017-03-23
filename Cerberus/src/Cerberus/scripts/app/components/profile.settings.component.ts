import { Component }                    from '@angular/core'
import { FileUploader }                 from 'ng2-file-upload/ng2-file-upload';


const URL = '/api/account/avatar';

@Component({
    selector: 'profile-settings',
    templateUrl: './templates/profile.settings.html'
})
export class ProfileSettingsComponent {
    constructor() { }

    private uploader: FileUploader = new FileUploader({ url: URL });
    private upload_file(): void {
        this.uploader.uploadAll();
    }
    
}