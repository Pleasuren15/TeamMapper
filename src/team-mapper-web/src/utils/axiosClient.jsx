import axios from 'axios';

export async function getAllTasksAsync() {    
  try {
    const getAllUrl = 'http://localhost:5001/workitems';
    const response = await axios.get(getAllUrl);
    console.log('GET response:', response.data);
    return response.data;
  } catch (error) {
    console.error('Error during GET request:', error);
    throw error;
  }
}


export default getAllTasksAsync;