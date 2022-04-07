import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserForRegister } from 'src/app/model/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';
import Validation from 'src/app/utils/validation';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent implements OnInit {

  registrationForm!: FormGroup;
  user!: UserForRegister;
  userSubmitted: boolean = false;

  constructor(private fb: FormBuilder, private authService: AuthService, private alertity:AlertifyService) { }

  ngOnInit(): void {
    this.createRegistrationForm();
  }

  createRegistrationForm(){
    this.registrationForm = this.fb.group({
      userName: [null,Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(8)]],
      confirmPassword: [null, [Validators.required]],
      mobile: [null, [Validators.required, Validators.maxLength(20)]]
    },{validators: [Validation.match('password', 'confirmPassword')]})
  }

  userData(): UserForRegister  {
    return this.user = {
      userName: this.userName.value,
      email: this.email.value,
      password: this.password.value,
      mobile: this.mobile.value
    }
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------
  get userName() {
    return this.registrationForm.get('userName') as FormControl;
  }

  get email() {
    return this.registrationForm.get('email') as FormControl;
  }

  get password() {
    return this.registrationForm.get('password') as FormControl;
  }

  get confirmPassword() {
    return this.registrationForm.get('confirmPassword') as FormControl;
  }

  get mobile() {
    return this.registrationForm.get('mobile') as FormControl;
  }

  //---------------------------------------------------


  onSubmit() {
    console.log(this.registrationForm.value);
    this.userSubmitted = true;
    if(this.registrationForm.valid) {
      this.authService.registerUser(this.userData()).subscribe({
        next:() => {
          this.registrationForm.reset();
          this.userSubmitted = false;
          this.alertity.success("Congrats, you are successfully registered");
        }
      });
    }
  }



}
