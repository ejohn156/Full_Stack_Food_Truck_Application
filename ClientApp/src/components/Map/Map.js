import './Map.css'
import React, { Component } from 'react';
import mapboxgl from 'mapbox-gl'

mapboxgl.accessToken = process.env.REACT_APP_mapboxAPIKey

export default class Map extends Component {
  constructor(props) {
    super(props)
    this.state = {
      lng: 5,
      lat: 34,
      zoom: 2,
      profile: this.props.profile
    }
  }
  async componentDidUpdate() {
    if (this.props.profile !== this.state.profile)
      await this.setState({
        profile: this.props.profile
      })
  }
  componentDidMount() {
    const map = new mapboxgl.Map({
      container: this.mapContainer,
      style: 'mapbox://styles/mapbox/streets-v11',
      center: [this.state.lng, this.state.lat],
      zoom: this.state.zoom
    });
  }

  render() {

    return (
      
          <div ref={el => this.mapContainer = el} />
        
    );
  }

}
