import './Map.css'
import React, { Component } from 'react';
import mapboxgl from 'mapbox-gl'
import yelpApi from '../../util/API/Yelp'

mapboxgl.accessToken = process.env.REACT_APP_mapboxAPIKey

export default class Map extends Component {
  constructor(props) {
    super(props)
    this.state = {
      lng: -80.843,
      lat: 35.2271,
      zoom: 13,
      favorites: this.props.favorites,
      trucks: this.props.trucks
    }
  }
  componentDidUpdate() {
    
    if (this.props.favorites !== this.state.favorites) {
        this.setState({
            favorites: this.props.favorites,
        })
        console.log(this.props.favorites)
    }
    else if(this.props.trucks !== this.state.trucks){
        this.setState({
            trucks: this.props.trucks,
        })
        console.log(this.props.trucks)
    }
}
  componentDidMount() {
    const map = new mapboxgl.Map({
      container: this.mapContainer,
      style: 'mapbox://styles/mapbox/streets-v11',
      center: [this.state.lng, this.state.lat],
      zoom: this.state.zoom
    });
    console.log(this.props.profile)
    console.log(this.props.trucks)
  }

  
  render() {

    return (
      
          <div ref={el => this.mapContainer = el} />
        
    );
  }

}
