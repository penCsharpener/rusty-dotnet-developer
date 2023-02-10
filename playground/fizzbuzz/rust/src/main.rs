fn main() {
    for i in 1..=100 {
        // if_else_fizz_buzz(i)
        // match_fizz_buzz(i)
        trait_fizz_buzz(i)
    }
}

fn trait_fizz_buzz(i: i32) {
    trait Fizzy {
        fn fizzy(&self) -> String;
    }

    impl Fizzy for i32 {
        fn fizzy(&self) -> String {
            match (self % 3, self % 5) {
                (0, 0) => String::from("FizzBuzz"),
                (0, _) => String::from("Fizz"),
                (_, 0) => String::from("Buzz"),
                _ => format!("{}", self),
            }
        }
    }

    println!("{}", i.fizzy())
}

#[allow(dead_code)]
fn match_fizz_buzz(i: i32) {
    match (i % 3, i % 5) {
        (0, 0) => println!("FizzBuzz"),
        (0, _) => println!("Fizz"),
        (_, 0) => println!("Buzz"),
        _ => println!("{}", i),
    }
}

#[allow(dead_code)]
fn if_else_fizz_buzz(i: i32) {
    let divisible_by_three = i % 3 == 0;
    let divisible_by_five = i % 5 == 0;

    if divisible_by_three && divisible_by_five {
        println!("FizzBuzz")
    } else if divisible_by_five {
        println!("Buzz")
    } else if divisible_by_three {
        println!("Fizz")
    } else {
        println!("{}", i)
    }
}
