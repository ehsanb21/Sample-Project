import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { PersonCreateComponent } from './person-create/person-create.component';
import { PersonListComponent } from './person-list/person-list.component';
import { PersonEditComponent } from './person-edit/person-edit.component';
import { DxButtonModule, DxDataGridModule, DxFormModule, DxTextBoxModule, DxValidationSummaryModule, DxValidatorModule } from 'devextreme-angular';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,      
    PersonCreateComponent,
    PersonListComponent,
    PersonEditComponent
  ],
  imports: [
    DxButtonModule,
    DxDataGridModule,
    DxTextBoxModule,
    DxValidatorModule,
    DxValidationSummaryModule,
    DxFormModule,


    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PersonListComponent, pathMatch: 'full' },
      
      { path: 'person-list', component: PersonListComponent },
      { path: 'person-create', component: PersonCreateComponent },
      { path: 'update-person/:id', component: PersonEditComponent },
      
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
