import React from 'react';
import { Button } from '@mui/material';
import { GetDupa } from '../../services/sampleService';

export const HomePage = () => {
  return (
    <div>
      <Button onClick={GetDupa} style={{ backgroundColor: 'orange', width: '200px' }}>
        Elo elo
      </Button>
    </div>
  );
};
