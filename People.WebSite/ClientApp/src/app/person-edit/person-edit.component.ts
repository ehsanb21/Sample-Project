import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { City } from '../models/City';
import { Person } from "../models/Person";
import { State } from '../models/State';
import { CountryService } from '../services/Contry.Service';
import { PersonsServices } from '../services/Persons.Service';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.css']
})
export class PersonEditComponent implements OnInit {

  id: number | undefined;
  cites:City[] | undefined;
  states:State[] |undefined;
  namePattern: any = /^[^0-9]+$/;

  person: Person = new Person();
  constructor(private personService: PersonsServices,
    private countryService :CountryService,
    private route: ActivatedRoute,
    private router: Router) { }

  


  onFormSubmit = function (e: any) {
    debugger;
    
    
    notify({
      message: 'You have submitted the form',
      position: {
        my: 'center top',
        at: 'center top',
      },
    }, 'success', 3000);

    e.preventDefault();
  };

  submitButtonOptions = {
    text: "Submit the Form",
    useSubmitBehavior: true
  }
  handleSubmit = function (e: any) {
    setTimeout(() => {
      alert("Submitted");
    }, 1000);
    
    e.preventDefault();
  }



  async ngOnInit() {    
    this.id = this.route.snapshot.params['id'];
    await this.personService.getPersonById(this.id).toPromise().then(data => {
      this.person = data;
    });
    this.getStates();
    this.getCites(this.person.IranStateId);    
    
  }

  private getStates() {    
    this.countryService.getStateList().subscribe(data => {
      this.states = data;
    });
  }

  private getCites(id:number|undefined) {    
    this.countryService.getCityList(id).subscribe(data => {
      this.cites = data;
    });
  }

  onSubmit(){
    debugger;
    this.personService.updatePerson(this.person).subscribe( data =>{
      this.goToPersonList();
    }
    , error => console.log(error));
  }

  changeState=(e: any)=> {
    console.log(e);
    this.getCites(e.value);
  }

   onChangeState(event:Event){     
     this.getCites( Number ((event.target as HTMLInputElement).value));  
     this.person.IranCityId = 1;      
   }

  goToPersonList(){    
    this.router.navigate(['/person-list']);
  }

}
