import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from "../models/Person";
import { PersonsServices } from '../services/Persons.Service';

import { DxDataGridComponent } from 'devextreme-angular';


@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent | undefined;
  persons: Person[] = [];

  constructor(private PersonService: PersonsServices,
    private router: Router,
      ) {
  }

 

  ngOnInit(): void {
    this.getPersons();
  }
  private getPersons() {    
    this.PersonService.getPersonList().subscribe(data => {
      this.persons = data;
    });
  }  
  
  logEvent(eventName: any, e: any) {

    debugger;

    const id: number = e.data.Id;
    if (eventName === 'edit') {
      this.router.navigate(['update-person', id]);
    } else {

      this.PersonService.deletePerson(id).subscribe(data => {
        console.log(data);
        this.getPersons();
      })
    }
  }


}
