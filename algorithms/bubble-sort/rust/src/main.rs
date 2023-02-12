use rand::Rng;

fn main() {
    let mut array = get_random_numbers();

    let len = array.len();
    for i in 0..len - 1
    {
        for j in 0..len - i - 1 {
            if array[j] > array[j + 1] {
                let tmp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = tmp;
                println!("{:?}", array);
            }
        }
    }

}

fn get_random_numbers() -> Vec<u16> {
    let mut rng = rand::thread_rng();
    let mut rnd_numbers = Vec::new();

    for _x in 0..10
    {
         let r: u16 = rng.gen_range(1..=10000);
        rnd_numbers.push(r);
    }
    
    println!("Random number: {:?}", rnd_numbers);

    rnd_numbers
}