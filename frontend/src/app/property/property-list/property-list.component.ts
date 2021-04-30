import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPropertyBase } from 'src/app/model/ipropertybase';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  properties: Array<IPropertyBase>;
  SellRent = 1;
  today = new Date();
  City = '';
  searchCity = '';
  SortbyParam = '';
  sortDirection = "asc";

  constructor(private housingService: HousingService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    if(this.route.snapshot.url.toString()) {
      this.SellRent = 2;
    }

    this.housingService.getAllProperties(this.SellRent)
    .subscribe(data => {
      this.properties = data;
      console.log(data);
    }, error => {
      console.log("http error: ");
      console.log(error);
    });
  }

  onCityFilter() {
    this.searchCity = this.City;
  }

  onCityFilterClear() {
    this.searchCity = '';
    this.City = '';
  }

  onSortDirection() {
    if (this.sortDirection === 'desc') {
      this.sortDirection = 'asc';
    } else {
      this.sortDirection = 'desc';
    }
  }

}
