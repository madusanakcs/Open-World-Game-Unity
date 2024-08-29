create database spacdb;
use spacdb;


ALTER TABLE spacdb.questions MODIFY COLUMN general_feedback TEXT;

ALTER TABLE spacdb.questions AUTO_INCREMENT = 1;

INSERT INTO spacdb.questions (question_title, general_feedback) VALUES 
('What is the primary source of energy for most power grids around the world?', 'While the mix of energy sources varies by region, fossil fuels remain the dominant source for electricity generation globally, though renewable sources are on the rise.'),
('How does electricity typically travel from power plants to consumers?', 'Electricity is generated at power plants and then transmitted over long distances via high-voltage transmission lines. It''s then distributed to consumers through lower-voltage distribution networks.'),
('Why is energy efficiency important in homes and businesses?', 'Energy efficiency is crucial for reducing energy consumption, lowering energy bills, and minimizing the environmental footprint by decreasing greenhouse gas emissions.'),
('What is the primary goal of demand management in energy usage?', 'Demand management aims to ensure energy is used more efficiently, balancing the supply with the fluctuating demand to maintain grid stability and reduce costs.'),
('Which of the following is a common method used in demand management to encourage lower energy use during peak hours?', 'Lowering rates or providing incentives for reduced energy use during peak hours helps smooth out energy demand, benefiting both the grid and consumer.'),
('Benefits to the consumer from demand management include:', 'Participating in demand management programs can lead to significant savings on electricity bills for consumers by incentivizing energy use during off-peak hours.'),
('How does implementing demand management strategies benefit the environment?', 'Implementing demand management strategies plays a crucial role in environmental conservation by reducing the reliance on non-renewable energy sources and minimizing carbon emissions.'),
('What can be a direct benefit of participating in a demand management program for consumers?', 'Participation in demand management programs often results in direct benefits for consumers, such as savings on electricity bills, by encouraging energy use during less expensive, off-peak hours.'),
('Why is load shifting important in demand management?', 'Load shifting is a critical component of demand management, aimed at moving energy use from peak to off-peak hours. This helps balance the power grid, reduces the need for additional power plants, and can lead to cost savings for consumers and utility providers alike.'),
('Which of the following electric loads can be effectively managed as part of a demand management program?', 'Demand management programs focus on adjusting the usage of flexible and non-critical electric loads to optimize energy consumption. Residential air conditioning units, for example, can be adjusted without compromising safety or critical operations, making them ideal for inclusion in these programs.');



INSERT INTO spacdb.answers (answer_title, is_correct, specific_feedback, question_id) VALUES 
('Solar power', 0, 'Solar power is growing but is not the primary source globally.', 1),
('Wind power', 0, 'Wind power is significant in some areas but not the main source worldwide.', 1),
('Fossil fuels', 1, 'Correct! Fossil fuels, including coal, natural gas, and oil, are currently the primary energy source for most power grids.', 1),
('Hydropower', 0, 'Hydropower is a key renewable source but not the primary source globally.', 1),
('Through water pipes', 0, 'Water pipes are used for plumbing, not electrical transmission.', 2),
('Via transmission and distribution networks', 1, 'Correct! Transmission and distribution networks are essential for delivering electricity from power plants to consumers.', 2),
('Directly from generators to homes', 0, 'Electricity must be transmitted and distributed over networks; it doesn''t go directly from generators to homes.', 2),
('Through the internet', 0, 'The internet is a network for data, not electricity.', 2),
('It increases energy consumption', 0, 'Energy efficiency aims to reduce, not increase, consumption.', 3),
('It leads to higher energy costs', 0, 'The goal of energy efficiency is to lower costs, not raise them.', 3),
('It reduces energy bills and environmental impact', 1, 'Correct! Energy efficiency helps in saving on energy bills and reducing the environmental impact.', 3),
('It has no impact on the environment', 0, 'Energy efficiency has a significant positive impact on the environment by reducing emissions.', 3),
('To increase the overall energy consumption', 0, 'This is the opposite of demand management''s goal, which aims to optimize, not increase, energy use.', 4),
('To balance energy supply and demand', 1, 'Correct! Balancing energy supply and demand helps improve grid reliability and efficiency.', 4),
('To eliminate the use of renewable energy sources', 0, 'Demand management often encourages the integration of renewable energy sources, not their elimination.', 4),
('To double the energy costs for consumers', 0, 'The goal is to potentially lower or optimize costs, not increase them.', 4),
('Increasing energy prices during off-peak hours', 0, 'This approach would not encourage lower usage during peak times.', 5),
('Providing incentives for high energy consumption', 0, 'Incentives are typically offered for reducing consumption, not increasing it.', 5),
('Offering lower rates or incentives for using less energy during peak times', 1, 'Correct! Incentives for lower usage during peak hours help manage demand effectively.', 5),
('Discouraging the use of energy-efficient appliances', 0, 'Energy-efficient appliances are actually encouraged as part of demand management strategies.', 5),
('Higher energy bills', 0, 'The goal of demand management is to offer savings, not to increase bills.', 6),
('Less control over their energy use', 0, 'Participants typically gain greater control and flexibility over their energy use.', 6),
('Savings on their electricity bill', 1, 'Correct! Saving on electricity bills is a significant benefit for consumers who participate in demand management programs.', 6),
('Reduced internet connectivity', 0, 'Demand management does not impact internet connectivity.', 6),
('By significantly increasing carbon emissions', 0, 'Demand management aims to decrease, not increase, carbon emissions.', 7),
('By reducing reliance on fossil fuels and lowering carbon emissions', 1, 'Correct! Reducing reliance on fossil fuels and lowering carbon emissions are key environmental benefits of demand management.', 7),
('By eliminating the need for public transportation', 0, 'Demand management strategies do not involve transportation policies directly.', 7),
('By discouraging the use of renewable energy', 0, 'These strategies typically encourage, rather than discourage, the use of renewable energy sources.', 7),
('Higher energy bills', 0, 'The goal of demand management is to offer savings, not to increase bills.', 8),
('Less control over their energy use', 0, 'Participants typically gain greater control and flexibility over their energy use.', 8),
('Savings on their electricity bill', 1, 'Correct! Saving on electricity bills is a significant benefit for consumers who participate in demand management programs.', 8),
('Reduced internet connectivity', 0, 'Demand management does not impact internet connectivity.', 8),
('It increases the energy load during peak times', 0, 'The purpose of load shifting is to decrease, not increase, the load during peak times to help balance energy demand.', 9),
('It shifts energy usage to times when demand is higher', 0, 'Shifting energy usage to higher demand times would counteract the goals of demand management, which seeks to alleviate these peaks.', 9),
('It helps balance the power grid by using energy during lower-demand periods', 1, 'Correct! By shifting energy use to lower-demand periods, we can achieve a more balanced and efficient use of the power grid.', 9),
('It makes energy more expensive during off-peak hours', 0, 'Load shifting is designed to take advantage of lower costs during off-peak hours, not to make energy more expensive.', 9),
('Fixed lighting systems in public areas', 0, 'While lighting can be managed, fixed systems in public areas often have safety implications that limit their flexibility.', 10),
('Emergency medical equipment', 0, 'Emergency medical equipment is critical and cannot be subject to demand management due to the risk to human life.', 10),
('Residential air conditioning units', 1, 'Correct! Residential air conditioning units are a significant and flexible load that can be adjusted to enhance grid efficiency without compromising comfort significantly.', 10),
('Data centers that require constant cooling', 0, 'Data centers have strict cooling requirements for operational integrity and may not offer the flexibility required for effective demand management.', 10);



