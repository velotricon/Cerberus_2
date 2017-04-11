import { Component, OnInit }            from '@angular/core'
import { FileUploader }                 from 'ng2-file-upload/ng2-file-upload';
import { LoggerService }                from '../services/logger.service';
import { IdentityService }              from '../services/identity.service';
import { GenericResultContainer }       from '../containers/generic.result.container';

const URL = '/api/account/avatar';

@Component({
    selector: 'profile-settings',
    templateUrl: './templates/profile.settings.html'
})
export class ProfileSettingsComponent implements OnInit {
    constructor(private service: IdentityService) { }

    private uploader: FileUploader = new FileUploader({ url: URL });
    private username: string;
    private avatar_path: string;
    private email: string;

    private upload_file(): void {
        this.uploader.uploadAll();
    }

    private on_remove_success(Result: GenericResultContainer): void {

    }

    private on_remove_error(Error: any): void {

    }

    private remove_avatar_click(): void {

    }

    private init_profile_info(Info: any): void {
        this.username = Info.Username;
        this.avatar_path = Info.AvatarPath;
    }

    ngOnInit(): void {

    }
}